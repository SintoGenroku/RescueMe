using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using RescueMe.Client.Models.Emergency;
using RescueMe.Client.ViewModels.Abstracts;
using RescueMe.Common;

namespace RescueMe.Client.ViewModels
{
    [QueryProperty("Emergency", "Emergency")]
    public partial class EmergencyDetailsViewModel : ViewModelBase
    {
        [ObservableProperty]
        Emergency emergency;

        public EmergencyDetailsViewModel()
        {
        }

        [ICommand]
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
