using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Vshope.Application.Util.Abstr;

namespace Vshope.Application.Util
{
    public class WebRequestService: IWebRequestService
    {
        public string GetRequest(string host, string req)
        {
            string str = "";

            var Vk = new HttpClient();
            Vk.DefaultRequestHeaders.Add("Connection", "close");

            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(req);
            request.UseDefaultCredentials = true;
            request.Method = "GET";
            request.Host = host;
            request.ContentType = "application/json";
            request.KeepAlive = false;
            
            using (HttpWebResponse vkResponse = (HttpWebResponse) request.GetResponse())
            using (var stream = vkResponse.GetResponseStream())
            using (var streamReader = new StreamReader(stream, Encoding.UTF8))
            {
                str = streamReader.ReadToEnd();
            }
            return str;
        }
    }
}
