using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BH.Parser
{
    internal class WriterToJson
    {
        public void Write(List<DataNews> listDataNews, string nameFile)
        {
            string fullNameFile = nameFile + ".json";
            StreamWriter sw = new StreamWriter(fullNameFile);
            sw.WriteLine("[");
            foreach (var dataNews in listDataNews)
            {
                string output = JsonConvert.SerializeObject(dataNews);
                sw.WriteLine(output);
                if (dataNews != listDataNews[listDataNews.Count-1])
                {
                    sw.WriteLine(",");
                }
            }
            sw.WriteLine("]");
            sw.Close();
        }
    }
}
