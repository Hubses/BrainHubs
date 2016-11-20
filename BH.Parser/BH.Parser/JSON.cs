using System.Runtime.Serialization;

namespace BH.Parser
{
    [DataContract]
    class Json
    {
        [DataMember]
        public BlockNews[] News { get; set; }
        [DataMember]
        public BlockNews[] Economics { get; set; }
        [DataMember]
        public BlockNews[] Politics { get; set; }
        [DataMember]
        public BlockNews[] Society { get; set; }
        [DataMember]
        public BlockNews[] Sport { get; set; }
        [DataMember]
        public BlockNews[] World { get; set; }
        [DataMember]
        public Categories[] Categories { get; set; }

        public Json(BlockNews[] news, BlockNews[] economics, BlockNews[] politics, BlockNews[] society, BlockNews[] sport, BlockNews[] world, Categories[] categories)
        {
            this.News = news;
            this.Economics = economics;
            this.Society = society;
            this.Politics = politics;
            this.World = world;
            this.Sport = sport;
            this.Categories = categories;
        }
    }
}
