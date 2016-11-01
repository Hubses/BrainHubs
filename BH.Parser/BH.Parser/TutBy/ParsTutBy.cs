using System.Collections.Generic;

namespace BH.Parser.TutBy
{
    public class ParsTutBy : IPars
    {
        private readonly List<DataNews> _dataNews = new List<DataNews>();
        private readonly string[] _namesCategories = { "politics", "economics", "society", "world", "sport" };

        public void Start()
        {
            var searchLinkNewsTutBy = new SearchLinkNewsTutBy();
            var parsNewsTutBy = new ParsNewsTutBy();
            foreach (var nameCategory in _namesCategories)
            {
                var linksNews = searchLinkNewsTutBy.GetLinksNewsByCategory(nameCategory);
                var dataNews = parsNewsTutBy.GetDataNews(linksNews, nameCategory);
                _dataNews.AddRange(dataNews);
            }
        }

        public List<DataNews> DataNews => _dataNews;
    }
}
