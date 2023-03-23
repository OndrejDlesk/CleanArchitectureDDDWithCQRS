using Example.Application.Authentication.Commands.Register;
using Example.Application.Authentication.Common;
using Example.Application.Authentication.Queries.Login;
using Example.Contracts.Authentication;
using Mapster;

namespace Example.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}