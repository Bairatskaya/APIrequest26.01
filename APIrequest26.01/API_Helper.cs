using RestSharp;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;


namespace APIrequest26._01
{
    public class API_Helper
    {
        public IRestResponse SendApiRequest(object body,Dictionary<string,string> headers,string link,Method type)
        {
            RestClient client = new RestClient(link)
            {
                Timeout = 10000
            };
            RestRequest request = new RestRequest(Method.POST);
            foreach (var header in headers)
            request.AddHeader(header.Key, header.Value);
            request.AddJsonBody(body);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = client.Execute(request);
            return response;
        }
        public Cookie ExtractCookie(IRestResponse response, string cookieName)
        {
            Cookie result = null;
            foreach (var cookie in response.Cookies)
                if (cookie.Name.Equals(cookieName))
                    result = new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Path, null);
            return result;
        }
        public static byte[] GetPicRequest(string picUrl)
        {
            var client = new RestClient(picUrl);
            var request = new RestRequest(Method.GET);
            byte[] picInByte = client.DownloadData(request);
            return picInByte;
        }


    }
}
