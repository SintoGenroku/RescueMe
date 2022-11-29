using Microsoft.Toolkit.Mvvm.Input;
using RescueMe.Client.Services.Abstracts;
using RescueMe.Client.ViewModels.Abstracts;
using RescueMe.Client.Views;
using RescueMe.UserModels.Requests;
using System.ComponentModel.DataAnnotations;

namespace RescueMe.Client.ViewModels
{
    public partial class RegistrationViewModel : ViewModelBase
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        
        public string Pasport{ get; set; }

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }


        private IConnectivity _connectivity;

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        private readonly IAuthenticationService _authenticationService;

        public RegistrationViewModel(IConnectivity connectivity, IAuthenticationService authenticationService)
        {
            ErrorMessageViewModel = new MessageViewModel();

            _connectivity = connectivity;
            _authenticationService = authenticationService;
        }

        [ICommand]
        async Task RegisterAsync()
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
                var registrationRequest = new UserRegistrationModel
                {
                    Name = Name,
                    Phone = PhoneNumber,
                    PassportId = Pasport,
                    Password = Password,
                    PasswordConfirm = ConfirmPassword

                };
                
               // await _authenticationService.RegisterAsync(registrationRequest);
                await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                IsBusy = false;

            }
        }
    }
}
