using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Refit;
using RescueMe.Client.Services;
using RescueMe.Client.Services.Abstracts;
using RescueMe.Client.ViewModels;
using RescueMe.Client.Views;
using RescueMe.Refit;

namespace RescueMe.Client;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		var services = builder.Services;
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Sansation/Sansation_Bold.ttf", "SansationBold");
            });

		services.AddSingleton<IConnectivity>(Connectivity.Current);
		services.AddScoped<LoginViewModel>();
        services.AddSingleton<MessageViewModel>();
		services.AddScoped<LoginPage>();
		services.AddScoped<IAuthenticationService, AuthenticationService>();

        services.AddRefitClient<IAccountApi>()
			.ConfigureHttpClient(config =>
			{
				//var stringUrl = builder.Configuration.GetSection("IdentityUri").Value;
				config.BaseAddress = new Uri("http://localhost:5045");
			});

        return builder.Build();
	}
} 
