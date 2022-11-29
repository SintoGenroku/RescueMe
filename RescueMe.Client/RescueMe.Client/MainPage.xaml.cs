using RescueMe.Client.ViewModels;

namespace RescueMe.Client;

public partial class MainPage : ContentPage
{


	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

