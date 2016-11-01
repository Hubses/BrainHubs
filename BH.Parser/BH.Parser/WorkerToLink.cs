using System;
using System.Collections;

namespace BH.Parser
{
    static class WorkerToLink
    {
        public static ArrayList SelectedLink(IEnumerable listLinks, string url)
        {
            var newList = new ArrayList();
            foreach (var link in listLinks)
            {
                var str = link.ToString();
                if (str.IndexOf(url, StringComparison.Ordinal) >= 0)
                {
                    if (SearchLink(newList,str)) continue;
                    newList.Add(link);
                }
            }

            return newList;
        }

        public static ArrayList ConverLinks(IEnumerable listLinks, string url)
        {
            var newListLinks = new ArrayList();

            foreach (var link in listLinks)
            {
                newListLinks.Add(url + link.ToString().Substring(1));
            }

            return newListLinks;
        }

        private static bool SearchLink(ArrayList listLinks, string link)
        {
            bool result = false;
            foreach (var linkList in listLinks)
            {
                if (linkList.ToString() == link)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
