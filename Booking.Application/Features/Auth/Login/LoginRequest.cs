using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.Features.Auth.Login;

public sealed record LoginRequest(
    string Email,
    string Password
);