using System;
using System.Collections;
using System.Text;
using HtmlAgilityPack;
using System.Net;
using System.IO;

namespace BH.Parser
{
    public  class Parser
    {
        private readonly HtmlDocument _document = new HtmlDocument();
        private string _url;

        public Parser(string url)
        {
            _url = url;
            Loading();
        }

        private string GetRequest(string url)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
                httpWebRequest.AllowAutoRedirect = false;
                httpWebRequest.Method = "GET";
                httpWebRequest.Referer = "http://google.com";
                using (var httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse())
                {
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        if (stream != null)
                        {
                            if (httpWebResponse.CharacterSet != null)
                            {
                                using (var reader = new StreamReader(stream,
                                    Encoding.GetEncoding(httpWebResponse.CharacterSet)))
                                {
                                    return reader.ReadToEnd();
                                }
                            }
                            return string.Empty;
                        }
                        return string.Empty;
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public void Reboot(string url)
        {
            _url = url;
            Loading();
        }

        public string ParserString(string requestName)
        {
            var bodyNode = _document.DocumentNode.SelectSingleNode(requestName);
            var str = bodyNode.InnerText;
            return str;
        }

        public  string ParserStringByAttributes(string requestName, string attribut)
        {
            var bodyNode = _document.DocumentNode.SelectSingleNode(requestName);
            var information = "";
            try
            {
                information = bodyNode.Attributes[attribut].Value;
            }
            catch (NullReferenceException) { }           
            return information;
        }

        public string ParserText(string requestName, string tag)
        {
            var line = new ArrayList();
            var bodyNode = _document.DocumentNode.SelectSingleNode(requestName);
            string text = bodyNode.InnerText.Trim();
            return text;
        }


        private void Loading()
        {
            _document.LoadHtml(GetRequest(_url));
        }

        public ArrayList ParserArrayByAttributes(string requestName, string attribut)
        {
            var list = new ArrayList();
            var bodyNode = _document.DocumentNode.SelectNodes(requestName);
            foreach (var node in bodyNode)
            {
                list.Add(node.Attributes[attribut].Value);
            }
            return list;
        }

        public ArrayList ParserArrayByTag(string requestName, string tag)
        {
            var list = new ArrayList();
            var i = 1;
            while (true)
            {
                var bodyNode = _document.DocumentNode.SelectSingleNode(requestName + '/' + tag + "[" + i + "]");
                if (bodyNode == null)
                {
                    break;
                }
                list.Add(bodyNode.InnerText);
                i++;
            }
            return list;
        }
    }
}
