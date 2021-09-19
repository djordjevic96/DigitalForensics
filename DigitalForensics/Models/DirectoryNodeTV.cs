using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalForensics.Models
{
    [Serializable]
    public class DirectoryNodeTV : TreeNode
    {
        public DirectoryNodeTV(string dText):base(dText)
        {
            Size = 0;
            NumberOfFiles = 0;
            Expanded = false;
            SizeCalculate = false;
            NumberOfFilesCalculated = false;
        }
        public long Size { get; set; }
        public int NumberOfFiles { get; set; }
        public bool Expanded { get; set; }

        public bool SizeCalculate { get; set; }
        public bool NumberOfFilesCalculated { get; set; }
    }
}
