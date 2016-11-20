using System.Runtime.Serialization;

namespace BH.Parser
{
    [DataContract]
    class Categories
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Category { get; set; }

        public Categories(int id, string category)
        {
            this.Id = id;
            this.Category = category;
        }
    }
}
