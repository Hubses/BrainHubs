using System;
using System.Collections;
using System.Collections.Generic;

namespace BH.Parser.TutBy
{
    class ParsNewsTutBy
    {
        public List<DataNews> GetDataNews(ArrayList linksNews, string category)
        {
            var dataNews = new List<DataNews>();
            var parser = new Parser("http://news.tut.by/");
            const string NameSite = "tut.by";

            foreach (var linkNews in linksNews)
            {
                parser.Reboot(linkNews.ToString());
                var paragraphsList = parser.ParserArrayByTag("//*[@id='article_body']", "p");
                var text = ConvertParagrehsListToString(paragraphsList);
                text = GetValidText(text);
                var keywords = parser.ParserStringByAttributes("//*[@name='news_keywords']", "content");
                var header = parser.ParserString("//*[@class='m_header']/h1");
                header = GetValidText(header);
                var imageUrl = parser.ParserStringByAttributes("//*[@id='article_body']/figure[1]/img", "src");
                var ruNameCategory = GetRuCategory(category);
                var news = new DataNews(header, imageUrl, text, keywords, ruNameCategory, NameSite);
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
                case "economics":
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

        private string GetValidText(string text)
        {
            string validText = text;
            validText = validText.Replace("\"","'");
            if (text.IndexOf("<!--", StringComparison.Ordinal) != -1)
            {
                var startPoint = validText.IndexOf("<!--", StringComparison.Ordinal);
                var finalPoint = validText.LastIndexOf("-->", StringComparison.Ordinal);
                validText = validText.Remove(startPoint, finalPoint - startPoint);
            }
            return validText;
        }
    }
}
