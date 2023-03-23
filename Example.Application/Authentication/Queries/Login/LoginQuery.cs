
using ErrorOr;
using Example.Application.Authentication.Common;
using MediatR;

namespace Example.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}