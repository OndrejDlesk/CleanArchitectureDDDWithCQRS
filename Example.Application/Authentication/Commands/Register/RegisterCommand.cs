using ErrorOr;
using Example.Application.Authentication.Common;
using MediatR;

namespace Example.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}