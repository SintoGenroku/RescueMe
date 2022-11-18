using RescueMe.Client.State.Navigators;
using RescueMe.Client.ViewModels.Abstracts;
using RescueMe.Client.ViewModels.Factories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RescueMe.Client.ViewModels.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;

        public ViewModelFactory(CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            _createLoginViewModel = createLoginViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login: 
                    return new LoginViewModel();

                default: 
                    throw new ArgumentException("The ViewType doesn't have a ViewModel", "viewType");
            }
        }
    }
}
