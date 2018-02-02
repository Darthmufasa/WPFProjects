using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebFrameworks.Interfaces;

namespace WebFrameworks.Classes
{
    public class RestWebService : IRestWebService
    {
        public IRestSerializable RestGet<IRestSerializable>(HttpWebRequest request, bool toXML)
        {
            throw new NotImplementedException();
        }

        public IRestSerializable RestPost<IRestSerializable>(HttpWebRequest request, string postString, bool toXML)
        {
            throw new NotImplementedException();
        }

        public IRestSerializable RestPut<IRestSerializable>(HttpWebRequest request, string postString, bool toXML)
        {
            throw new NotImplementedException();
        }
    }
}
