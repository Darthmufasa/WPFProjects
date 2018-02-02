using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WebFrameworks.Interfaces;

namespace WebFrameworks.Classes
{
    public abstract class JSONSerializable :IJsonSerializable
    {

        public T FromJSON<T>(string json)
        {
            T response = default(T);
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                serializer.MaxJsonLength = Int32.MaxValue;
                response = serializer.Deserialize<T>(json);

            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }
        public string ToJSON()
        {
            string response;
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                serializer.MaxJsonLength = Int32.MaxValue;
                response = serializer.Serialize(this);

            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }
    }
}
