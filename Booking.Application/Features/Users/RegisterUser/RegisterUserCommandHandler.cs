using Booking.Application.Abstractions.Security;
using Booking.Application.Abstractions.UserRegister;
using Booking.Application.Features.Users.RegisterUser;
using Booking.Application.Generics.Interfaces;
using Booking.Domain.Roles;
using Booking.Domain.UserRoles;
using Booking.Domain.Users;
using MediatR;

namespace Booking.Application.Features.Users.Register;

public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IGenericRepository<Role> _roleRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserCommandHandler(
        IUserRepository userRepository,
        IGenericRepository<Role> roleRepository,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var isUnique = await _userRepository
            .IsEmailUnique(request.UserDto.Email, cancellationToken);

        if (!isUnique)
            throw new Exception("Email already exists.");


        var passwordHash = _passwordHasher.Hash(request.UserDto.Password);

        var defaultRole = await _roleRepository
            .FirstOrDefaultAsync(r => r.IsDefault, cancellationToken);

        if (defaultRole is null)
            throw new Exception("No default role found.");

        var user = User.CreateUser(request.UserDto, passwordHash);

        var userRole = UserRole.CreateDefaultUserRole(user, defaultRole);
        user.UserRoles.Add(userRole);

        await _userRepository.AddAsync(user, cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}