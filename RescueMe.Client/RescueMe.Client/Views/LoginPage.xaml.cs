using RescueMe.Client.ViewModels;

namespace RescueMe.Client.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();
		BindingContext = loginViewModel;
	}

	private async void RegistrationRedirect(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("Registration");
    }
}