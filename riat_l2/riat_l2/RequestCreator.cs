using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;


namespace riat_l2
{
    class RequestCreator
    {
        private HttpWebRequest webRequest;
        private HttpWebResponse webResponse;
        private Stream responseStream;
        public bool CreateRequest(RequestType requestType, string url, string method, out string response, byte[] data = null)
        {
            response = null;
            webRequest = (HttpWebRequest)WebRequest.Create($"{url}/{method}");
            webRequest.Timeout = 1000;
            webRequest.Method = requestType.ToString();
            try
            {
                if (requestType == RequestType.GET)
                {
                    webResponse = (HttpWebResponse)webRequest.GetResponse();
                    responseStream = webResponse.GetResponseStream();
                    using (var streamReader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        response = streamReader.ReadToEnd();
                        return true;
                    }
                }
                if (data != null)
                {
                    webRequest.ContentLength = data.Length;
                    using (var stream = webRequest.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                    webRequest.GetResponse();
                    return true;
                }
                return false;
            }
            catch (WebException e)
            {
                if (e.Status != WebExceptionStatus.Timeout
                    && e.Status != WebExceptionStatus.ReceiveFailure
                    && e.Status != WebExceptionStatus.NameResolutionFailure)
                {
                    throw;
                }
                return false;
            }
            
        }
    }
}
