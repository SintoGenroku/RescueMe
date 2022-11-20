using RescueMe.Client.ViewModels;

namespace RescueMe.Client.Views;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage(RegistrationViewModel registrationViewModel)
    {
		InitializeComponent();
        BindingContext = registrationViewModel;
    }

    private async void LoginRedirect(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Login");
    }
}