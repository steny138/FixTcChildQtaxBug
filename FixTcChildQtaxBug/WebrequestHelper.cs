using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionExAPI.TK.Utility
{
    public class WebRequestHelper
    {
        public static string GetApi(string url, string contentType = "application/json")
        {
            try
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                request.ContentType = contentType;
                request.Method = "GET";

                string ret = string.Empty;
                using (System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse())
                {
                    using (System.IO.StreamReader tReader = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        ret = tReader.ReadToEnd();
                    }
                }
                return ret;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string PostApi(string url, string postdata, string contentType = "application/json", Dictionary<string, string> optionHeader = null)
        {
            try
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                request.ContentType = contentType;
                request.Method = "POST";

                if(optionHeader != null)
                {
                    foreach (string key in optionHeader.Keys)
                    {
                        request.Headers.Add(key, optionHeader[key]);
                    }
                }

                byte[] bs = System.Text.Encoding.UTF8.GetBytes(postdata);
                request.ContentLength = bs.Length;
                using (System.IO.Stream req = request.GetRequestStream())
                {
                    req.Write(bs, 0, bs.Length);
                }
                string ret = string.Empty;
                using (System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse())
                {
                    using (System.IO.StreamReader tReader = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        ret = tReader.ReadToEnd();
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }

}
