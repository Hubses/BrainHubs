using System.Collections;
using System.Collections.Generic;

namespace BH.Parser.RiaRu
{
    class ParsNewsRiaRu
    {
        public List<DataNews> GetDataNews(ArrayList linksNews, string category)
        {
            var dataNews = new List<DataNews>();
            var parser = new Parser("https://ria.ru");
            const string NameSite = "ria.ru";
            foreach (var linkNews in linksNews)
            {
                parser.Reboot(linkNews.ToString());
                var paragraphsList = parser.ParserArrayByTag("//*[@class='b-article__body js-mediator-article']", "p");
                var text = ConvertParagrehsListToString(paragraphsList);
                var keyword = parser.ParserStringByAttributes("//*[@name='keywords']", "content");
                var headline = parser.ParserString("//*[@id='wrPage']/div[3]/div[4]/div[3]/div[2]/div[3]/div/div[1]/div[1]/div/div/h1/span");
                var imageUrl = parser.ParserStringByAttributes("//*[@class='b-article__announce-img-wr']/img", "src");
                var ruNameCategory = GetRuCategory(category);
                var news = new DataNews(headline, imageUrl, text, keyword, ruNameCategory, NameSite);
                dataNews.Add(news);
            }
            return dataNews;
        }

        private string ConvertParagrehsListToString(ArrayList paragraphsList)
        {
            var text = "";
            foreach (object paragraph in paragraphsList)
            {
                text += paragraph;
                text += "<br>";
            }
            return text;
        }

        private string GetRuCategory(string category)
        {
            string ruNameCategory;
            switch (category)
            {
                case "politics":
                    ruNameCategory = "Политика";
                    break;
                case "economy":
                    ruNameCategory = "Экономика";
                    break;
                case "society":
                    ruNameCategory = "Общество";
                    break;
                case "world":
                    ruNameCategory = "В мире";
                    break;
                case "sport":
                    ruNameCategory = "Спорт";
                    break;
                default:
                    ruNameCategory = null;
                    break;
            }
            return ruNameCategory;
        }
    }
}
