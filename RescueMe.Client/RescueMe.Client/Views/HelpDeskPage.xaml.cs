using RescueMe.Client.ViewModels;

namespace RescueMe.Client.Views;

public partial class HelpDeskPage : ContentPage
{
    private readonly HelpDeskViewModel _helpDeskViewModel;
    public HelpDeskPage(HelpDeskViewModel helpDeskViewModel)
	{
		InitializeComponent();
		BindingContext = helpDeskViewModel;
        _helpDeskViewModel = helpDeskViewModel;

    }

    public void EmergencySearchTextChanged(object sender, TextChangedEventArgs e)
    {
        if(string.IsNullOrEmpty(EmergencySearch.Text))
        {
            EmergencyList.ItemsSource = _helpDeskViewModel.Emergencies;
        }
        else
        {
            EmergencyList.ItemsSource = _helpDeskViewModel.Emergencies.Where(e => e.Tittle.ToLower().Contains(EmergencySearch.Text.ToLower())).ToList();

        }
        
    }
}