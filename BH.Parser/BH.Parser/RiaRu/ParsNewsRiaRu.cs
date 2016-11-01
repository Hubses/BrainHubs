using System.Collections;
using System.Collections.Generic;

namespace BH.Parser.RiaRu
{
    class ParsNewsRiaRu
    {
        
        private readonly Parser _parser = new Parser("https://ria.ru");
        private const string NameSite = "ria.ru";

        public List<DataNews> GetDataNews(ArrayList linksNews, string category)
        {
            List<DataNews> dataNews = new List<DataNews>();
            foreach (var linkNews in linksNews)
            {
                _parser.Reboot(linkNews.ToString());

                var paragraphsList = _parser.ParserArrayByTag("//*[@class='b-article__body js-mediator-article']", "p");
                var text = WorkerToString.ConvertParagrehsListToString(paragraphsList);
                text = WorkerToString.GetValidText(text);

                var keyword = _parser.ParserStringByAttributes("//*[@name='keywords']", "content");

                var header = _parser.ParserString("//*[@id='wrPage']/div[3]/div[4]/div[3]/div[2]/div[3]/div/div[1]/div[1]/div/div/h1/span");
                header = WorkerToString.GetValidText(header);

                var imageUrl = _parser.ParserStringByAttributes("//*[@class='b-article__announce-img-wr']/img", "src");

                var ruNameCategory = WorkerToString.GetRuNameCategory(category);

                var news = new DataNews(header, imageUrl, text, keyword, ruNameCategory, NameSite);
                dataNews.Add(news);
            }
            return dataNews;
        }   
    }
}
