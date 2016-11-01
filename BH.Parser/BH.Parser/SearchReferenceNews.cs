using System.Collections.Generic;

namespace BH.Parser
{
    internal class SearchReferenceNews
    {
        private const int MinCountMatcher = 3;
        public List<DataNews> SearchReference(List<DataNews> listDataNews)
        {
            for (var i = 0; i < listDataNews.Count; i++)
            {

                for (var j = 0; j < listDataNews.Count; j++)
                {
                    if (i == j) continue;

                    if (!IsNewsReference(listDataNews[i], listDataNews[j])) continue;

                    var listReferenceId = listDataNews[i].ReferenceNewsId == null
                        ? new List<int>()
                        : new List<int>(listDataNews[i].ReferenceNewsId);
                    listReferenceId.Add(listDataNews[j].Id);
                    listDataNews[i].ReferenceNewsId = listReferenceId.ToArray();
                }
            }
            return listDataNews;
        }


        private bool IsNewsReference(DataNews firstNews, DataNews secondNews)
        {
            var coffecent = 0;
            var firstkeywords = firstNews.Keywords;
            var firstArrayKeywordsNews = WorkerToString.ConverStringKeywordsToArrayKeywords(firstkeywords);
            var secondkeywords = secondNews.Keywords;
            var secondArrayKeywordsNews = WorkerToString.ConverStringKeywordsToArrayKeywords(secondkeywords);
            if (firstArrayKeywordsNews == null || secondArrayKeywordsNews ==null)
            {
                return false;
            }
            foreach (var keywordFirstNews in firstArrayKeywordsNews)
            {
                foreach (var keywordSecondNews in secondArrayKeywordsNews)
                {
                    if (keywordFirstNews == keywordSecondNews)
                    {
                        coffecent++;
                    }
                }
            }

            return coffecent >= MinCountMatcher;
        }


    }
}
