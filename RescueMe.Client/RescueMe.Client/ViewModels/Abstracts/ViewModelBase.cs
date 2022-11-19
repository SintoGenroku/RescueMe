using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace RescueMe.Client.ViewModels.Abstracts
{

    public partial class ViewModelBase : ObservableObject
    {
        [AlsoNotifyChangeFor(nameof(IsNotBusy))]
        [ObservableProperty]
        bool isBusy;

        public bool IsNotBusy => !isBusy;


    }
}
