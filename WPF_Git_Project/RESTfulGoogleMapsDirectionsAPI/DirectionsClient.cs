using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebFrameworks.Classes;

namespace RESTfulGoogleMapsDirectionsAPI
{
    public class DirectionsClient : RestWebService
    {
        const string xmlBaseURI = "https://maps.googleapis.com/maps/api/directions/xml?";
        const string jsonBaseURI = "https://maps.googleapis.com/maps/api/directions/json?";

        public dynamic GetDirections(DirectionsRequest request,bool useXML)
        {
            LastException = null;
            dynamic responseObject = default(dynamic);
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(GetUri(request,useXML));
                webRequest.Accept = useXML ? "application/xml" : "application/json";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                try
                {
                    responseObject = this.RestGet<dynamic>(webRequest, useXML);
                }catch(Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception e)
            {
                LastException = e;
            }
            return responseObject;
        }
        public Task<dynamic> GetDirectionsAsync(DirectionsRequest request, bool useXML)
        {
            return Task.Factory.StartNew(() =>
            {
                return GetDirections(request, useXML);
            });
        }

        private static string GetParameterString(DirectionsRequest request)
        {
            string parameters = string.Empty;
            foreach(var prop in request.GetType().GetProperties())
            {
                if(prop.GetValue(request,null) != null)
                {
                    parameters += $"{prop.Name}={GetParameterValue(request,prop)}&";
                }
            }
            if (parameters.EndsWith("&"))
            {
                parameters = parameters.TrimEnd('&');
            }
            return parameters;
        }
        private static string GetParameterValue(DirectionsRequest request,PropertyInfo prop)
        {
            string paramValue = string.Empty;
            if (prop.PropertyType.IsArray)
            {
                var collection = (IEnumerable)prop.GetValue(request, null);
                foreach(var item in collection)
                {
                    paramValue += $"{item.ToString()}|";
                }
            }
            else
            {
                paramValue = prop.GetValue(request, null).ToString();
            }
            if (paramValue.EndsWith("|"))
            {
                paramValue = paramValue.TrimEnd('|');
            }
            return HttpUtility.UrlEncode(paramValue);
        }
        private static Uri GetUri(DirectionsRequest request,bool useXML)
        {
            string url = $"{SelectBaseUri(useXML)}{GetParameterString(request)}";
            return new Uri(url);
        }
        private static string SelectBaseUri(bool useXML)
        {
            return useXML ? xmlBaseURI : jsonBaseURI;
        }
    }
}
