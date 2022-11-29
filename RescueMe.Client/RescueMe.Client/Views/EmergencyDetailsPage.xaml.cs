using RescueMe.Client.ViewModels;

namespace RescueMe.Client.Views;

public partial class EmergencyDetailsPage : ContentPage
{
	public EmergencyDetailsPage(EmergencyDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}