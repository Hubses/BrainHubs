using System.Collections.Generic;

namespace BH.Parser.TutBy
{
    public class ParsTutBy : IPars
    {
        private readonly string[] _namesCategories = { "politics", "economics", "society", "world"};
        private readonly SearchLinkNewsTutBy _searchLinkNewsTutBy = new SearchLinkNewsTutBy();
        private readonly ParsNewsTutBy _parsNewsTutBy = new ParsNewsTutBy();
        private readonly List<DataNews> _dataNews = new List<DataNews>();
        public void Start()
        {

            foreach (var nameCategory in _namesCategories)
            {
                var linksNews = _searchLinkNewsTutBy.GetLinksNewsByCategory(nameCategory);
                var dataNews = _parsNewsTutBy.GetDataNews(linksNews, nameCategory);
                _dataNews.AddRange(dataNews);
            }
        }

        public List<DataNews> DataNews => _dataNews;
    }
}
