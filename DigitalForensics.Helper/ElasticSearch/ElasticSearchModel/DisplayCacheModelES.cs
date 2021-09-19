using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalForensics.Helper.ElasticSearch.ElasticSearchModel
{
    public class DisplayCacheModelES
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public int NumberOfFiles { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastModificationTime { get; set; }
        public DateTime CacheDate { get; set; }
    }
}
