using FluentValidation;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;
using VenueHosting.Application.Features.Authentication.Login;
using VenueHosting.Application.Features.Authentication.Register;
using VenueHosting.SharedKernel.Behaviours;

namespace VenueHosting.Module.User.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {


        return serviceCollection;
    }
}