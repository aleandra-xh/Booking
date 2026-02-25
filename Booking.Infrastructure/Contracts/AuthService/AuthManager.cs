using Booking.Application.Abstractions.LogIn;
using Booking.Application.Abstractions.Security;
using Booking.Application.Features.Auth.Login;
using Booking.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Booking.Domain.Users;
using Microsoft.IdentityModel.Tokens;

namespace Booking.Infrastructure.Contracts.AuthService;

public sealed class AuthManager : IAuthManager
{
    private readonly IConfiguration _configuration;
    private readonly BookingDbContext _context;
    private readonly IPasswordHasher _passwordHasher;
    public AuthManager(
    BookingDbContext context,
    IConfiguration configuration,
    IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
        _configuration = configuration;
        _context = context;
    }
    // Get User from DB
    public async Task<LoginResponse> LoginAsync(string email, string password, CancellationToken ct)
    {
        var user = await _context.Users
    .Include(u => u.UserRoles)
        .ThenInclude(ur => ur.Role)
    .FirstOrDefaultAsync(u => u.Email == email, ct);
        if (user is null)
            throw new Exception("Invalid credentials");

        if (!_passwordHasher.Verify(password, user.Password))
            throw new Exception("Invalid credentials");

        var token = CreateToken(user);

        var expiresMinutes = int.Parse(_configuration["Jwt:ExpiresMinutes"]!);

        return new LoginResponse(
            token,
            "Bearer",
            expiresMinutes * 60
        );
    }


    private string CreateToken(User user)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = GetClaims(user);
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = _configuration["Jwt:SecretKey"];
        if (string.IsNullOrWhiteSpace(key))
            throw new Exception("Jwt:SecretKey is missing.");

        var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private static List<Claim> GetClaims(User user)
    {
        var roles = user.UserRoles
        .Select(ur => ur.Role.Name.ToString())
        .ToList();

        var claims = new List<Claim>
    {
        new(JwtRegisteredClaimNames.Sub, user.Email),
        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new(ClaimTypes.NameIdentifier, user.Id.ToString())
    };

        claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(
       SigningCredentials signingCredentials,
       List<Claim> claims)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var expiresMinutesStr = _configuration["Jwt:ExpiresMinutes"];

        if (!int.TryParse(expiresMinutesStr, out var expiresMinutes))
            expiresMinutes = 60;

        return new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiresMinutes),
            signingCredentials: signingCredentials
        );
    }
}