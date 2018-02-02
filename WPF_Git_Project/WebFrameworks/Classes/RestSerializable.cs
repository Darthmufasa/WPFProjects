using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using WebFrameworks.Interfaces;

namespace WebFrameworks.Classes
{
    public abstract class RestSerializable :  IRestSerializable
    {
        public T FromXML<T>(string xml)
        {
            T response = default(T);
            try
            {
                using (var sr = new StringReader(xml))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    response = (T)serializer.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }
        public string ToXML()
        {
            string response;
            try
            {
                using (var sw = new StringWriter())
                {
                    XmlSerializer serializer = new XmlSerializer(this.GetType());
                    serializer.Serialize(sw, this);
                    response = sw.ToString();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return response;
        }

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
