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
            _parser.Reboot(Url + nameCategory + "/");
            var listLinksNews = _parser.ParserArrayByAttributes("//*[@class='b-list__item']/a", "href");
            listLinksNews = WorkerToLink.ConverLinks(listLinksNews, Url);
            listLinksNews = WorkerToLink.SelectedLink(listLinksNews, Url + nameCategory);
            return listLinksNews;
        }

    }
}