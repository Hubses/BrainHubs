using System.Collections;
using System.Collections.Generic;

namespace BH.Parser.TutBy
{
    class ParsNewsTutBy
    {
        
        private readonly Parser _parser = new Parser("http://news.tut.by/");
        private const string NameSite = "tut.by";

        public List<DataNews> GetDataNews(ArrayList linksNews, string category)
        {
             List<DataNews> dataNews = new List<DataNews>();
            foreach (var linkNews in linksNews)
            {
                _parser.Reboot(linkNews.ToString());

                var paragraphsList = _parser.ParserArrayByTag("//*[@id='article_body']", "p");

                var text = WorkerToString.ConvertParagrehsListToString(paragraphsList);
                text = WorkerToString.GetValidText(text);

                var keywords = _parser.ParserStringByAttributes("//*[@name='news_keywords']", "content");

                var header = _parser.ParserString("//*[@class='m_header']/h1");
                header = WorkerToString.GetValidText(header);

                var imageUrl = _parser.ParserStringByAttributes("//*[@id='article_body']/figure[1]/img", "src");

                var ruNameCategory = WorkerToString.GetRuNameCategory(category);

                var news = new DataNews(header, imageUrl, text, keywords, ruNameCategory, NameSite);
                dataNews.Add(news);
            }
            return dataNews;
        }
    }
}
