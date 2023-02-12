using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Transcribe.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {        

        public INavigation Navigation { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetProperty<TType>(string propertyName, TType value, ref TType underlyingProperty)
        {
            underlyingProperty = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
