using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.Parser.RiaRu;
using BH.Parser.TutBy;

namespace BH.Parser
{
    class Manager
    {
        private List<DataNews> _list;
        private WriterToJSON _writerToJson = new WriterToJSON();
        private readonly SearchReferenceNews _searchReferenceNews = new SearchReferenceNews();
        private readonly string[] _categories = { "Politics", "Economics", "Society", "World", "Sport" };
        public List<DataNews> List
        {
            get
            {
                return _list;
            }

            set
            {
                _list = value;
            }
        }

        public void Start()
        {
            List<DataNews> listDataNews = new List<DataNews>();
            ParsTutBy parsTutBy = new ParsTutBy();
            parsTutBy.Start();
            listDataNews.AddRange(parsTutBy.DataNews);

            ParsRiaRu parsRiaRu = new ParsRiaRu();
            parsRiaRu.Start();
            listDataNews.AddRange(parsRiaRu.DataNews);

            listDataNews = CraetIDForListDataNews(listDataNews);

            listDataNews = _searchReferenceNews.SearchReference(listDataNews);

            WriteAllDataNewsToJSOn(listDataNews);

            List = listDataNews;
        }


        private List<DataNews> CraetIDForListDataNews(List<DataNews> listDataNews)
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


        private void WriteDataToJSON(List<DataNews> listDataNews, string nameFile)
        {
            _writerToJson.Write(listDataNews,nameFile);
        }

        private void WriteAllDataNewsToJSOn(List<DataNews> listDataNews)
        {
            foreach (var category in _categories)
            {
                var ruCategory = GetRuCategory(category);
                var listNews = new List<DataNews>();
                foreach (var dataNews in listDataNews)
                {

                    if (ruCategory == dataNews.Category)
                    {
                        listNews.Add(dataNews);
                    }
                }
                WriteDataToJSON(listNews, category);
            }
        }

        private string GetRuCategory(string category)
        {
            string ruNameCategory;
            switch (category)
            {
                case "Politics":
                    ruNameCategory = "Политика";
                    break;
                case "Economics":
                    ruNameCategory = "Экономика";
                    break;
                case "Society":
                    ruNameCategory = "Общество";
                    break;
                case "World":
                    ruNameCategory = "В мире";
                    break;
                case "Sport":
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
