using System.Runtime.Serialization;

namespace BH.Parser
{
    [DataContract]
    public class DataNews
    {
        [DataMember]
        public int Id { get; set; } 
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Keywords { get; set; }
        [DataMember]
        public string Header { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public int[] ReferenceNewsId { get; set; }
        [DataMember]
        public string NameSite { get; set; }

        public DataNews(string header, string imageUrl,string text, string keywords,
                         string category, string nameSite)
        {
            Header = header;
            ImageUrl = imageUrl;
            Text = text;
            Keywords = keywords;
            Category = category;
            NameSite = nameSite;
        }
    }
}
