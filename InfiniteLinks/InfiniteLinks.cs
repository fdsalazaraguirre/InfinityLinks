using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace InfiniteLinks
{
    [TestClass]
    public class UnitTestInfiniteLink
    {
        private WebRequest wrGETURL;
        private string sUrl;
        private ArrayList SecretMessages = new ArrayList();
        private ArrayList AllLinks = new ArrayList();
        [TestMethod]
        public void GetLink()
        {
            Console.WriteLine("probando");
            try
            {
                var Html =ReadHtml("qds.html");
                SecretMessages.Add(GetSecretMessage(Html));
                ArrayList links123;
                links123 = RecorrerLinks(GetNextLink(Html));
                do
                {
                    if (links123 != null)
                    {
                        links123=RecorrerLinks(GetNextLink(Html));
                    }
                } while (links123 != null);
                foreach(var secretmessage in SecretMessages)
                {
                    Console.WriteLine(secretmessage);
                }
                Assert.IsNull(links123);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Assert.Fail();
            }

        }

        private String ReadHtml(string pagename)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://cdn.hackerrank.com/hackerrank/static/contests/capture-the-flag/infinite/"+pagename);
            request.Method = "GET";
            var response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8);
            var html = readStream.ReadToEnd();
            response.Close();
            readStream.Close();
            return html;
        }

        private String GetSecretMessage(string html)
        {
            string secretmessage = ""; 
            HtmlDocument doc = new HtmlDocument();
            ArrayList Links = new ArrayList();
            doc.LoadHtml(html);
            if (doc.DocumentNode.SelectNodes("//font[@color='blue']") != null) { 
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//font[@color='blue']"))
                {
                    secretmessage = link.InnerText;
                }
                secretmessage = secretmessage.Replace("Secret Phrase: ","");
            }
            return secretmessage;
        }

        private ArrayList GetNextLink(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            ArrayList Links = new ArrayList();
            doc.LoadHtml(html);
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                if(!Links.Contains(att.Value.ToString()))
                {
                    Links.Add(att.Value.ToString());
                }
            }
            return Links;
        }

        private ArrayList RecorrerLinks(ArrayList Links)
        {
            ArrayList list = new ArrayList();
            foreach (var link in Links)
            {
                if (!AllLinks.Contains(link)) { 
                    var Html = ReadHtml(link.ToString());
                    if (!SecretMessages.Contains(GetSecretMessage(Html))) { 
                        SecretMessages.Add(GetSecretMessage(Html));
                    }
                    list.AddRange(GetNextLink(Html));
                    AllLinks.Add(link);
                }
            }
            if (list.Count > 0)
            {
                return RecorrerLinks(list);
            }
            return null;
        }
    }
}
