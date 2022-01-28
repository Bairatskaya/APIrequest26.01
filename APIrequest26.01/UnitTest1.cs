using RestSharp;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.IO;

namespace APIrequest26._01
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var body = new Dictionary<string, string>
            {
                {"l_","12301@gmail.com"},
                {"pw_","123"}

            };
            var headers = new Dictionary<string, string>
            {
                {"Content-Type","application/javascript"}
            };

            var response = new API_Helper().SendApiRequest(body, headers, "https://ek.ua/", RestSharp.Method.POST);
            var cookie = new API_Helper().ExtractCookie(response, "PHPSESSID");
            //var cookie2 = new API_Helper().ExtractCookie(response, "access_token");

            IWebDriver chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://ek.ua/");
            System.Threading.Thread.Sleep(10000);

            chrome.Manage().Cookies.AddCookie(cookie);
            //chrome.Manage().Cookies.AddCookie(cookie2);

            chrome.Navigate().GoToUrl("https://ek.ua/");
            System.Threading.Thread.Sleep(5000);
            //chrome.Close();
        }
        [Fact]
        public void DownloudPic()
        {
            byte[] content = API_Helper.GetPicRequest("https://i.pinimg.com/originals/e8/9a/ae/e89aae77cead87e332063ce9a9140d0e.jpg");
            File.WriteAllBytes(Path.Combine("/Picture", "picture.jpg"), content);
        }

        [Fact]
        public void UploadPic()
        {
        var client = new RestClient("https://radikal.ru/");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
        request.AddHeader("Cookie", "SID=8c5c54284eb3463d83d067386c331b55; UID=90dfa8fea9d0490e95c8a5751dd8b4ce");
        request.AddFile("picture", "/Picture/krasivye-pupsiki-shchenochki-pomeranskogo-shpica-photo-f572.jpg");
        IRestResponse response = client.Execute(request);
           
        }


    }
}
