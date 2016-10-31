using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Parser
{
    class SearchReferenceNews
    {
        public List<DataNews> SearchReference(List<DataNews> listDataNews)
        {
            for (int i = 0; i < listDataNews.Count; i++)
            {

                for (int j = 0; j < listDataNews.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (IsNewsReference(listDataNews[i], listDataNews[j]))
                    {
                        List<int> listReferenceId;
                        if (listDataNews[i].ReferenceNewsId == null)
                        {
                            listReferenceId = new List<int>();
                        }
                        else
                        {
                            listReferenceId = new List<int>(listDataNews[i].ReferenceNewsId);
                        }
                        listReferenceId.Add(listDataNews[j].Id);
                        listDataNews[i].ReferenceNewsId =  listReferenceId.ToArray();
                    }
                }
            }
            return listDataNews;
        }


        private bool IsNewsReference(DataNews firstNews, DataNews secondNews)
        {
            double coffecent = 0;
            string firstkeywords = firstNews.Keywords;
            string[] firstArrayKeywordsNews = ConverStringToArray(firstkeywords);
            string secondkeywords = secondNews.Keywords;
            string[] secondArrayKeywordsNews = ConverStringToArray(secondkeywords);
            if (firstArrayKeywordsNews == null || secondArrayKeywordsNews ==null)
            {
                return false;
            }
            for (int i = 0; i < firstArrayKeywordsNews.Length; i++)
            {
                for (int j = 0; j < secondArrayKeywordsNews.Length; j++)
                {
                    if (firstArrayKeywordsNews[i] == secondArrayKeywordsNews[j])
                    {
                        coffecent++;
                    }
                }
            }
            const int MinCountMatcher = 3;
            if (coffecent >= MinCountMatcher)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string[] ConverStringToArray(string keywords)
        {
            if (keywords =="")
            {
                return null;
            }
            List<string> arrayKeywords = new List<string>();
            int i = 0;
            keywords = keywords.Replace(",", " ");
            while (true)
            {
                int positeonComma = keywords.IndexOf(" ",i+1);
                if (positeonComma == -1)
                {
                    break;
                }
                string keyword = keywords.Substring(i, positeonComma - i);
                keyword = keyword.Replace(" ","");
                keyword = keyword.ToLower();
                if (keyword.Length <=2)
                {
                    i = positeonComma;
                    continue;
                }
                int lenght = keyword.Length;
                int subsString = Convert.ToInt32(lenght * 0.75);
                keyword = keyword.Substring(0, subsString);
                i = positeonComma;
                arrayKeywords.Add(keyword);
            }
            arrayKeywords = CheakListKeywords(arrayKeywords);
            return arrayKeywords.ToArray();
        }

        private List<string> CheakListKeywords(List<string> arrayKeywords)
        {
            for (int i = 0; i < arrayKeywords.Count; i++)
            {
                if (arrayKeywords[i]== "")
                {
                    arrayKeywords.Remove(arrayKeywords[i]);
                }
            }
            return arrayKeywords;
        }
    }
}
