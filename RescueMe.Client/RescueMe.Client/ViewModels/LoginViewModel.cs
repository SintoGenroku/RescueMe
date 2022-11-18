using RescueMe.Client.State.Navigators.Abstracts;
using RescueMe.Client.ViewModels.Abstracts;
using System.Windows.Input;

namespace RescueMe.Client.ViewModels
{
    public class LoginViewModel : ViewModelBase
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

        public bool CanLogin => !string.IsNullOrEmpty(PhoneNumber) && !string.IsNullOrEmpty(Password);

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }
        public ICommand LoginCommand { get; }
       /* public ICommand ViewRegisterCommand { get; }
        public LoginViewModel(IAuthenticator authenticator, INavigator loginRenavigator, INavigator registerRenavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();

            LoginCommand = new LoginCommand(this, authenticator, loginRenavigator);
            ViewRegisterCommand = new RenavigateCommand(registerRenavigator);
        }*/

        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();
            
            base.Dispose();
        }
    }
}
