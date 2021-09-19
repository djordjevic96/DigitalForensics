using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalForensics.ElasticSearch.ElasticSearchModel
{
    public class CacheModelStat
    {
        public long Size { get; set; }
        public int NumberOfFiles { get; set; }

        public CacheModelStat()
        {
            Size = 0;
            NumberOfFiles = 0;
        }
    }
}
