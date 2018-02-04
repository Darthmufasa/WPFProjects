using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFrameworks.Classes
{
    public class WebService : UpdatedPropertyChanged
    {
        Exception lastException;
        string username;
        string password;

        public Exception LastException {
            get => lastException;
            set => SetProperty(ref lastException, value);
        }
        public string Username {
            get => username;
            set => SetProperty(ref username, value);
        }
        public string Password {
            get => password;
            set => SetProperty(ref password, value);
        }
    }
}
