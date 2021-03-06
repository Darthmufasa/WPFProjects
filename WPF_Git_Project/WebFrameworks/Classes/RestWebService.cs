﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebFrameworks.Interfaces;

namespace WebFrameworks.Classes
{
    public abstract class RestWebService : WebService, IRestWebService
    {

        public IRestSerializable RestGet<IRestSerializable>(HttpWebRequest request, bool toXML)
        {
            IRestSerializable responseObject = default(IRestSerializable);
            string responseStream;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    responseStream = sr.ReadToEnd();
                    if (toXML)
                    {
                        responseObject = RestSerializable.FromXML<IRestSerializable>(responseStream);
                    }
                    else
                    {
                        responseObject = RestSerializable.FromJSON<IRestSerializable>(responseStream);
                    }
                }
            }catch(Exception e)
            {
                e = CheckForWebException(e);
                LastException = e;
            }
            return responseObject;
        }

        public IRestSerializable RestPost<IRestSerializable>(HttpWebRequest request, string postString, bool toXML)
        {
            IRestSerializable responseObject = default(IRestSerializable);
            string responseStream;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
                requestWriter.Write(postString);
                using (var sr = new StreamWriter(request.GetRequestStream()))
                {
                    sr.Write(postString);
                }
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    responseStream = sr.ReadToEnd();
                    if (toXML)
                    {
                        responseObject = RestSerializable.FromXML<IRestSerializable>(responseStream);
                    }
                    else
                    {
                        responseObject = RestSerializable.FromJSON<IRestSerializable>(responseStream);
                    }
                }
            }
            catch (Exception e)
            {
                e = CheckForWebException(e);
                LastException = e;
            }
            return responseObject;
        }
        

        private static Exception CheckForWebException(Exception e)
        {
            if (e.GetType() == typeof(WebException))
            {
                WebException webEx = e as WebException;
                if (webEx.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)webEx.Response)
                    {
                        using (var sr = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            string error = sr.ReadToEnd();
                            Console.WriteLine(error);
                            e = new Exception(error);
                        }
                    }
                }
            }

            return e;
        }
    }
}
