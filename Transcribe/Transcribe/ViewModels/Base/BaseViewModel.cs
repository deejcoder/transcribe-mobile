using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Transcribe.ViewModels.Base
{
    public class BaseViewModel
    {        
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
