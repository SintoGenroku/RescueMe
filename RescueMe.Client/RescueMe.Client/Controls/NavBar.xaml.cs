namespace RescueMe.Client.Controls;

public partial class NavBar : ContentView
{
	public NavBar()
	{
		InitializeComponent();
	}

	private async void HelpDeskRedirect(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("HelpDesk");
    }

	private async void MainPageRedirect(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("Main");
    }
}