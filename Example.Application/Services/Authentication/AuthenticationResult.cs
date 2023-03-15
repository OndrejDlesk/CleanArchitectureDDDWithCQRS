using Example.Domain.Entities;

namespace Example.Application.Services.Authentication
{
    public record AuthenticationResult
    (
        User User,
        string Token);
}
