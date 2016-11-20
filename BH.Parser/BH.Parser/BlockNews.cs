using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.Parser
{
    class BlockNews
    {
        public DataNews[] blockNews;

        public BlockNews(DataNews[] blockNews)
        {
            this.blockNews = blockNews;
        }

        public DataNews[] GetBlockNews => blockNews;
    }
}
