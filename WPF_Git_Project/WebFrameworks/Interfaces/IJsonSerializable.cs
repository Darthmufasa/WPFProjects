using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFrameworks.Interfaces
{
    public interface IJsonSerializable
    {
        T FromJSON<T>(string json);
        string ToJSON();
    }
}
