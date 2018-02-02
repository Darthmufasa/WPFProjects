using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFrameworks.Interfaces
{
    interface IUpdatedPropertyChanged : INotifyPropertyChanged
    {
        new event PropertyChangedEventHandler PropertyChanged;
        void SetProperty<T>(ref T refField, T newValue, string propertyName);
    }
}
