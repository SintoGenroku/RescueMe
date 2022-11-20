using RescueMe.Client.Views;

namespace RescueMe.Client;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("Registration", typeof(RegistrationPage));
		Routing.RegisterRoute("Login", typeof(LoginPage));
    }
}
