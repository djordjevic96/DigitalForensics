using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalForensics.Models;
using System.IO;

namespace DigitalForensics.HelperClass
{
    public enum SortBy
    {
        Name,
        Size,
        NumberOfFiles,
        TimeCreated,
        TimeLastAccessed,
        TimeLastModified
    }

    public class TreeNodeSorting: System.Collections.IComparer
    {
        public SortBy SortMethod { get; set; }
        public bool Desc { get; set; }

        public TreeNodeSorting()
        {
            Desc = false;
        }

        public int Compare(object x, object y)
        {
            if(x is DirectoryNodeTV && y is DirectoryNodeTV)
            {
                return CompareDir(x as DirectoryNodeTV, y as DirectoryNodeTV);
            }
            if(!(x is DirectoryNodeTV) && !(y is DirectoryNodeTV))
            {
                return CompareFiles(x as TreeNode, y as TreeNode);
            }
            return 0;
        }

        public int CompareDir(DirectoryNodeTV x, DirectoryNodeTV y)
        {
            int result = 0;
            switch (SortMethod)
            {
                case SortBy.Name:
                    result = String.Compare(x.Name, y.Name);
                    break;
                case SortBy.Size:
                    result = x.Size >= y.Size ? 1 : -1;
                    break;
                case SortBy.NumberOfFiles:
                    result = x.NumberOfFiles >= y.NumberOfFiles ? 1 : -1;
                    break;
                case SortBy.TimeLastAccessed:
                    result = DateTime.Compare((x.Tag as DirectoryInfo).LastAccessTime, (y.Tag as DirectoryInfo).LastAccessTime);
                    break;
                case SortBy.TimeLastModified:
                    result = DateTime.Compare((x.Tag as DirectoryInfo).LastWriteTime, (y.Tag as DirectoryInfo).LastWriteTime);
                    break;
                case SortBy.TimeCreated:
                    result = DateTime.Compare((x.Tag as DirectoryInfo).CreationTime, (y.Tag as DirectoryInfo).CreationTime);
                    break;
                default:
                    break;

            }

            if(Desc && result !=0)
            {
                result *= -1;
            }
            return result;

        }

        public int CompareFiles(TreeNode x, TreeNode y)
        {
            int result = 0;
            switch (SortMethod)
            {
                case SortBy.Name:
                    result = String.Compare(x.Name, y.Name);
                    break;
                case SortBy.Size:
                    result = (x.Tag as FileInfo).Length >= (y.Tag as FileInfo).Length ? 1 : -1;
                    break;
                case SortBy.TimeLastAccessed:
                    result = DateTime.Compare((x.Tag as FileInfo).LastAccessTime, (y.Tag as FileInfo).LastAccessTime);
                    break;
                case SortBy.TimeLastModified:
                    result = DateTime.Compare((x.Tag as FileInfo).LastWriteTime, (y.Tag as FileInfo).LastWriteTime);
                    break;
                case SortBy.TimeCreated:
                    result = DateTime.Compare((x.Tag as FileInfo).CreationTime, (y.Tag as FileInfo).CreationTime);
                    break;
                default:
                    break;
            }

            if (Desc && result != 0)
            {
                result = 2 % result + 1;
            }

            return result;
        }
    }
}
