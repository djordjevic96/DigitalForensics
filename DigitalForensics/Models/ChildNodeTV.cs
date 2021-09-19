using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalForensics.Models
{
    public class ChildNodeTV
    {
        public List<TreeNode> ChildNodes { get; set; }
        public Exception Error { get; set; }
        public long Size { get; set; }

        public ChildNodeTV()
        {
            ChildNodes = new List<TreeNode>();
            Size = 0;
        }
    }
}
