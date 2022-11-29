using Microsoft.Toolkit.Mvvm.Input;
using MongoDB.Driver.GeoJsonObjectModel;
using RescueMe.Client.ViewModels.Abstracts;
using RescueMe.HelpModels.RequestModels;
using RescueMe.Refit;
using System.IdentityModel.Tokens.Jwt;

namespace RescueMe.Client.ViewModels
{
    public partial class MainPageViewModel : ViewModelBase
    {
        private readonly IGeolocation _geolocation;
        private readonly ILifeguardApi _lifeguardApi;

        public MainPageViewModel(IGeolocation geolocation, ILifeguardApi lifeguardApi)
        {
            _geolocation = geolocation;
            _lifeguardApi = lifeguardApi;
        }

        [ICommand]
        public async Task CallLifeguardAsync()
        {
            if(IsBusy)
                return;

            try
            {
                var location = await _geolocation.GetLastKnownLocationAsync();
                
                if(location == null)
                {
                    location = await _geolocation.GetLocationAsync(
                        new GeolocationRequest
                        {
                            DesiredAccuracy = GeolocationAccuracy.Best,
                            Timeout = TimeSpan.FromSeconds(30),
                        });
                }
               
/*                var token = Preferences.Get("access_token", null);
               
                if(token == null)
                {
                    throw new Exception("Пользователь не авторизован");
                }*/
                
               /* var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(token);
                var userId = jwtSecurityToken.Claims.First(claim => claim.Type == "sub").Value;
                */
                var request = new HelpRequestModel
                {
                    UserId = Guid.NewGuid(),//Guid.Parse(userId),
                    Location = new GeoLocation
                    {
                        Latitude =  location.Latitude,
                        Longitude = location.Longitude
                    }
                };
                
                await _lifeguardApi.CallLifeguardAsync(request);
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Ошибка", $"Проблема отправки геолокации: {ex.Message}", "Ок");
            }
        }

        [ICommand]
        public async Task GoToHelpDesk()
        {
            await Shell.Current.GoToAsync("HelpDesk");
        }
    }
}
