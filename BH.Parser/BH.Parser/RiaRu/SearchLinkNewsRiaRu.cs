using System;
using System.Collections;

namespace BH.Parser.RiaRu
{
    internal class SearchLinkNewsRiaRu
    {
        private const string Url = "https://ria.ru/";
        private readonly Parser _parser = new Parser(Url);

        public ArrayList GetLinksNewsByCategory(string nameCategory)
        {
            _parser.Reboot(Url + nameCategory+"/");
            var listLinksNews = _parser.ParserArrayByAttributes("//*[@class='b-list__item']/a", "href");
            listLinksNews = ConverLinks(listLinksNews);
            listLinksNews = SelectedUrl(listLinksNews, Url + nameCategory);
            return listLinksNews;
        }

        private ArrayList ConverLinks(ArrayList listLinks)
        {
            var newListLinks = new ArrayList();

            foreach (var link in listLinks)
            {
                newListLinks.Add(Url + link.ToString().Substring(1));
            }

            return newListLinks;
        }

        private ArrayList SelectedUrl(IEnumerable listLinks, string url)
        {
            var newList = new ArrayList();
            foreach (var link in listLinks)
            {
                string str = link.ToString();
                if (str.IndexOf(url, StringComparison.Ordinal) >= 0)
                {
                    if (newList.BinarySearch(link) == -1)
                    {
                        newList.Add(link);
                    }
                }
            }
            return newList;
        }
    }
}