using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RescueMe.Client.ViewModels.Abstracts
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;

    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public virtual void Dispose()
        { 
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged();
            return true;
        }
    }
}
