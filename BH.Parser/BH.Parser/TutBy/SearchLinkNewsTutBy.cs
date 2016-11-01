using System;
using System.Collections;

namespace BH.Parser.TutBy
{
    internal class SearchLinkNewsTutBy
    {
        private const string Url = "http://news.tut.by/";
        private readonly Parser _parser = new Parser(Url);

        public ArrayList GetLinksNewsByCategory(string nameCategory)
        {
            _parser.Reboot(Url + nameCategory);
            var listLinksNews = _parser.ParserArrayByAttributes("//*[@class='b-lists']/li/div[1]/a", "href");
            listLinksNews = WorkerToLink.SelectedLink(listLinksNews, Url + nameCategory);
            return listLinksNews;
        }

        
    }
}