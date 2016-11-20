using System.Collections.Generic;
using System.Linq;
using BH.Parser.RiaRu;
using BH.Parser.TutBy;

namespace BH.Parser
{
    internal class Manager
    {
        private readonly WriterToJson _writerToJson = new WriterToJson();
        private readonly SearchReferenceNews _searchReferenceNews = new SearchReferenceNews();
        private readonly string[] _categories = { "politics", "economics", "society", "world", "sport" };
        public List<DataNews> List { get; set; }

        public void Start()
        {
            List<DataNews> listDataNews = new List<DataNews>();

            ParsTutBy parsTutBy = new ParsTutBy();
            parsTutBy.Start();
            listDataNews.AddRange(parsTutBy.DataNews);

            ParsRiaRu parsRiaRu = new ParsRiaRu();
            parsRiaRu.Start();
            listDataNews.AddRange(parsRiaRu.DataNews);

            listDataNews = CraetIdForListDataNews(listDataNews);

            listDataNews = _searchReferenceNews.SearchReference(listDataNews);

            WriteAllDataNewsToJson(listDataNews);

            List = listDataNews;
        }


        private List<DataNews> CraetIdForListDataNews(List<DataNews> listDataNews)
        {
            var id = 0;
            var newListDataNews = new List<DataNews>();

            foreach (var dataNews in listDataNews)
            { 
                dataNews.Id = ++id;
                newListDataNews.Add(dataNews);
            }

            return newListDataNews;
        }


        private void WriteDataToJson(List<DataNews> listDataNews, string nameFile)
        {
            _writerToJson.Write(listDataNews,nameFile);
        }

        private void WriteAllDataNewsToJson(List<DataNews> listDataNews)
        {
            WriteDataToJson(listDataNews, "fullNewsList");
        }
    }
}
