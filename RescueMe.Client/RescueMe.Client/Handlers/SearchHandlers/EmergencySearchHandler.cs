using RescueMe.Common;

namespace RescueMe.Client.Handlers.SearchHandlers
{
    public class EmergencySearchHandler : SearchHandler
    {
        public List<Emergency> Emergencies { get; set; }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrEmpty(newValue))
            {
                ItemsSource = Emergencies;
            }
            else
            {
                ItemsSource = Emergencies.Where(e => e.Tittle.ToLower().Contains(newValue.ToLower())).ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            await Shell.Current.GoToAsync("EmergencyDetails", true,
                 new Dictionary<string, object>
                 {
                    {"Emergency", item }
                 });
        }
    }
}
