using System.Collections.Generic;

namespace BH.Parser.RiaRu
{
    public class ParsRiaRu : IPars
    {
        private readonly List<DataNews> _dataNews = new List<DataNews>();
        private readonly string[] _namesCategories = { "politics", "economy", "society", "world", "sport" };

        public void Start()
        {
            var searchLinkNewsRiaRu = new SearchLinkNewsRiaRu();
            var parsNewsRiaRu = new ParsNewsRiaRu();
            foreach (var nameCategory in _namesCategories)
            {
                var linksNews = searchLinkNewsRiaRu.GetLinksNewsByCategory(nameCategory);
                var dataNews = parsNewsRiaRu.GetDataNews(linksNews, nameCategory);
                _dataNews.AddRange(dataNews);
            }
        }

        public List<DataNews> DataNews => _dataNews;
    }
}
