using RescueMe.Client.State.Navigators.Abstracts;
using RescueMe.Client.ViewModels.Abstracts;

namespace RescueMe.Client.State.Navigators
{
    public class Navigator<TViewModel> : INavigator where TViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private readonly CreateViewModel<TViewModel> _createViewModel;
        
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel?.Dispose();

                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }
        public event Action StateChanged;


        public Navigator( CreateViewModel<TViewModel> createViewModel)
        {
            _createViewModel = createViewModel;
        }

        public void Renavigate()
        {
            CurrentViewModel = _createViewModel();
        }

    }
}
