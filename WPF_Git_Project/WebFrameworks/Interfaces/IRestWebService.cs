using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebFrameworks.Interfaces
{
    public interface IRestWebService
    {
        IRestSerializable RestGet<IRestSerializable>(HttpWebRequest request, bool toXML);
        IRestSerializable RestPost<IRestSerializable>(HttpWebRequest request, string postString, bool toXML);
        IRestSerializable RestPut<IRestSerializable>(HttpWebRequest request, string postString, bool toXML);
        IRestSerializable RestDelete<IRestSerializable>(HttpWebRequest request, string postString, bool toXML);
    }
}
