using Microsoft.Toolkit.Mvvm.Input;
using RescueMe.Client.Services.Abstracts;
using RescueMe.Client.ViewModels.Abstracts;
using RescueMe.UserModels.Requests;

namespace RescueMe.Client.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
    {
        private string _phoneNimber;
        public string PhoneNumber
        {
            get
            {
                return _phoneNimber;
            }
            set
            {
                _phoneNimber = value;
                OnPropertyChanged(nameof(_phoneNimber));
                OnPropertyChanged(nameof(CanLogin));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanLogin));
            }
        }

        private IConnectivity _connectivity;

        public bool CanLogin => !string.IsNullOrEmpty(PhoneNumber) && !string.IsNullOrEmpty(Password);

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        private readonly IAuthenticationService _authenticationService;

        public LoginViewModel(IConnectivity connectivity, IAuthenticationService authenticationService)
        {
            ErrorMessageViewModel = new MessageViewModel();

            _connectivity = connectivity;
            _authenticationService = authenticationService;
        }

        [ICommand]
        async Task LoginAsync()
        {
            if (IsBusy)
            {
                return;
            }
            try
            {
                if (_connectivity.NetworkAccess is not NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Internet Offline", "Check your internet and try again!", "Ok");
                    return;
                }
                var loginRequest = new UserLoginModel
                {
                    Phone = PhoneNumber,
                    Password = Password,
                };
                await _authenticationService.LoginAsync(loginRequest);
                await Shell.Current.GoToAsync($"{nameof(MainPage)}");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.ToString(), "ok");
            }
            finally
            {
                IsBusy = false;

            }
        }
    }
}
