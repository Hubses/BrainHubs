using System;
using System.Collections;
using System.Collections.Generic;

namespace BH.Parser
{
    public static class WorkerToString
    {
        public static string ConvertParagrehsListToString(IEnumerable paragraphsList)
        {
            var text = "";
            foreach (var paragraph in paragraphsList)
            {
                text += paragraph;
                text += "<br><br>";
            }
            return text;
        }

        public static string GetValidText(string text)
        {
            text = text.Replace("\"", "'");
            text = DeleteCommentsFromText(text);
            text = DeleteCodeFromText(text);
            return text;
        }

        private static string DeleteCommentsFromText(string text)
        {
            var newText = text;

            if (text.IndexOf("<!--", StringComparison.Ordinal) == -1) return newText;

            var startPoint = newText.IndexOf("<!--", StringComparison.Ordinal);
            var finalPoint = newText.LastIndexOf("-->", StringComparison.Ordinal);
            newText = newText.Remove(startPoint, finalPoint - startPoint);

            return newText;
        }

        private static string DeleteCodeFromText(string text)
        {
            string newText = text;
            if (text.IndexOf("$(", StringComparison.Ordinal) != -1)
            {
                var startPoint = newText.IndexOf("$(", StringComparison.Ordinal);
                var finalPoint = newText.LastIndexOf("});", StringComparison.Ordinal);
                newText = newText.Remove(startPoint, finalPoint - startPoint);
            }
            return newText;
        }

        public static string GetRuNameCategory(string category)
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

        public static  string[] ConverStringKeywordsToArrayKeywords(string keywords)
        {
            if (keywords == "")
            {
                return null;
            }
            var arrayKeywords = new List<string>();
            var i = 0;

            keywords = keywords.Replace(",", " ");

            while (true)
            {
                var positeonComma = keywords.IndexOf(" ", i + 1, StringComparison.Ordinal);
                if (positeonComma == -1)
                {
                    break;
                }
                var keyword = keywords.Substring(i, positeonComma - i);
                keyword = keyword.Replace(" ", "");
                if (keyword == keyword.ToUpper())
                {
                    arrayKeywords.Add(keyword);
                    i = positeonComma;
                    continue;
                }
                keyword = keyword.ToLower();
                if (keyword.Length <= 2)
                {
                    i = positeonComma;
                    continue;
                }
                var lenght = keyword.Length;
                var subsString = Convert.ToInt32(lenght * 0.75);
                keyword = keyword.Substring(0, subsString);
                i = positeonComma;
                arrayKeywords.Add(keyword);
            }
            arrayKeywords = CheakListKeywords(arrayKeywords);
            return arrayKeywords.ToArray();
        }

        private static List<string> CheakListKeywords(List<string> arrayKeywords)
        {
            for (var i = 0; i < arrayKeywords.Count; i++)
            {
                var keyword = arrayKeywords[i];
                if (arrayKeywords[i] == "")
                {
                    arrayKeywords.Remove(keyword);
                }
            }
            return arrayKeywords;
        }
    }
}
