using System.Collections.Generic;

namespace BH.Parser.RiaRu
{
    public class ParsRiaRu : IPars
    {
        private readonly string[] _namesCategories = { "politics", "economy", "society", "world", "sport" };
        private readonly SearchLinkNewsRiaRu _searchLinkNewsRiaRu = new SearchLinkNewsRiaRu();
        private readonly ParsNewsRiaRu _parsNewsRiaRu = new ParsNewsRiaRu();
        private readonly List<DataNews> _dataNews = new List<DataNews>();

        public void Start()
        {

            foreach (var nameCategory in _namesCategories)
            {
                var linksNews = _searchLinkNewsRiaRu.GetLinksNewsByCategory(nameCategory);
                var dataNews = _parsNewsRiaRu.GetDataNews(linksNews, nameCategory);
                _dataNews.AddRange(dataNews);
            }
        }

        public List<DataNews> DataNews => _dataNews;
    }
}
