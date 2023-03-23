using Example.Domain.Entities;

namespace Example.Application.Authentication.Common
{
    public record AuthenticationResult
    (
        User User,
        string Token);
}
