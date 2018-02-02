using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebFrameworks.Interfaces;

namespace WebFrameworks.Classes
{
    public class UpdatedPropertyChanged : IUpdatedPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void SetProperty<T>(ref T refField, T newValue, [CallerMemberName] string propertyName = null)
        {
            if(!Equals(refField, newValue))
            {
                refField = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
