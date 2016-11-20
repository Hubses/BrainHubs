using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BH.Parser
{
    internal class WriterToJson
    {
        static readonly MockCategories mockCategories = new MockCategories();
        private readonly Categories[] _categorieses = mockCategories.GetCategories();
        private BlockNews[] _blocksEconomicsNews;
        private BlockNews[] _blocksPoliticsNews;
        private BlockNews[] _blocksSocietyNews;
        private BlockNews[] _blocksSportNews;
        private BlockNews[] _blocksWorldNews;
        private BlockNews[] _blockNews;

        public void Write(List<DataNews> listDataNews, string nameFile)
        {
            ModernDataNews(listDataNews);
            _blockNews = GetBlockNews();
            Json json = new Json(_blockNews,_blocksEconomicsNews,_blocksPoliticsNews,_blocksSocietyNews,
                                    _blocksSportNews,_blocksWorldNews,_categorieses);
            string fullNameFile = nameFile + ".json";
            StreamWriter sw = new StreamWriter(fullNameFile);
            string output = JsonConvert.SerializeObject(json);
            sw.WriteLine(output);
            sw.Close();
        }


        private void ModernDataNews(List<DataNews> listDataNews)
        {
            List<DataNews>[] modernListDataNews = new List<DataNews>[_categorieses.Length];
            modernListDataNews[0] = new List<DataNews>();
            modernListDataNews[1] = new List<DataNews>();
            modernListDataNews[2] = new List<DataNews>();
            modernListDataNews[3] = new List<DataNews>();
            modernListDataNews[4] = new List<DataNews>();
        
            for (int i = 0; i < _categorieses.Length; i++)
            {
                for (int j = 0; j < listDataNews.Count; j++)
                {
                    if (listDataNews[j].Category == _categorieses[i].Category)
                    {
                        DataNews dataNews = listDataNews[j];
                        modernListDataNews[i].Add(dataNews);
                    }
                }
            }


            foreach (List<DataNews> listNews in modernListDataNews)
            {
                string currentSite = listNews[0].NameSite;
                int insertIndex = 1;
                for (int j = 1; j < listNews.Count; j++)
                {
                    if (insertIndex >= listNews.Count-1)
                    {
                        break;
                    }
                    if (listNews[j].NameSite != currentSite)
                    {
                        DataNews currentDataNews = listNews[j];
                        listNews.Remove(currentDataNews);
                        listNews.Insert(insertIndex, currentDataNews);
                        insertIndex += 2;
                    }
                }
            }

            List<BlockNews>[] listBlockNews = new List<BlockNews>[_categorieses.Length];
            listBlockNews[0] = new List<BlockNews>();
            listBlockNews[1] = new List<BlockNews>();
            listBlockNews[2] = new List<BlockNews>();
            listBlockNews[3] = new List<BlockNews>();
            listBlockNews[4] = new List<BlockNews>();

            for (var i = 0; i < modernListDataNews.Length; i++)
            {
                for (var j = 0; j < modernListDataNews[i].Count; j += 30)
                {
                    var length = 30;
                    if (j + length > modernListDataNews[i].Count)
                    {
                        length = modernListDataNews[i].Count - 1 - j;
                    }
                    DataNews[] dataNews = modernListDataNews[i].GetRange(j, length).ToArray();
                    BlockNews blockNews = new BlockNews(dataNews);
                    listBlockNews[i].Add(blockNews);
                }
            }

            _blocksEconomicsNews = listBlockNews[0].ToArray();
            _blocksPoliticsNews = listBlockNews[1].ToArray();
            _blocksSocietyNews = listBlockNews[2].ToArray();
            _blocksSportNews = listBlockNews[3].ToArray();
            _blocksWorldNews = listBlockNews[4].ToArray();

        }


        private bool Search(List<string> list, string sought)
        {
            bool result = false;

            foreach (var element  in list)
            {
                if (element == sought)
                {
                    result = true;
                    return result;
                }
            }

            return result;
        }

        private BlockNews[] GetBlockNews()
        {
            List<BlockNews> blockNews = new List<BlockNews>();
            blockNews.AddRange(_blocksEconomicsNews);
            blockNews.AddRange(_blocksPoliticsNews);
            blockNews.AddRange(_blocksSocietyNews);
            blockNews.AddRange(_blocksWorldNews);
            blockNews.AddRange(_blocksSportNews);

            return blockNews.ToArray();
        }
    }
}
