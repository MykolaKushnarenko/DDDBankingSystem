using Mapster;
using VenueHosting.Api.Host.Common.Requests;
using VenueHosting.Api.Host.Common.Responses;
using VenueHosting.Application.Features.Authentication.Login;
using VenueHosting.Application.Features.Authentication.Register;

namespace VenueHosting.Api.Host.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterUserCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<RegistrationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}