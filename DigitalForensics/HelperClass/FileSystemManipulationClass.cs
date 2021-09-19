using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalForensics.Models;
using System.IO;
using System.Windows.Forms;

namespace DigitalForensics.HelperClass
{
    public class FileSystemManipulationClass
    {
        public FileSystemManipulationClass() { }

        public ChildNodeTV GetDirectoryChilds(string dPath)
        {
            var directoryInfo = new DirectoryInfo(dPath);
            var result = new ChildNodeTV();

            try
            {
                var direcotryChilds = directoryInfo.EnumerateDirectories();
                var filesChilds = directoryInfo.EnumerateFiles();

                foreach(var directory in direcotryChilds)
                {
                    var directoryNode = new DirectoryNodeTV(directory.Name)
                    {
                        Tag = directory
                    };
                    directoryNode.Nodes.Add("dummy");
                    result.ChildNodes.Add(directoryNode);
                }

                foreach(var file in filesChilds)
                {
                    result.ChildNodes.Add(new TreeNode(file.Name)
                    {
                        Tag = file
                    });
                }
            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show("Unauthorized access to file: " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result.Error = ex;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception throw: " + ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result.Error = ex;
            }

            return result;
        }

        public int CalculateNumberOfFiles(DirectoryInfo rootNode)
        {
            if (rootNode == null)
            {
                return 0;
            }
            var result = 0;
            try
            {
                var subDirectories = rootNode.EnumerateDirectories();
                foreach(var subD in subDirectories)
                {
                    result += CalculateNumberOfFiles(subD);
                }

                result += rootNode.EnumerateFiles().Count();
            }
            catch(UnauthorizedAccessException ex)
            {
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }

            return result;
        }

        public long CalculateDirectorySize(DirectoryInfo directory)
        {
            if(directory == null)
            {
                return 0;
            }

            long size = 0;

            try
            {
                var subDirectories = directory.EnumerateDirectories();
                var files = directory.EnumerateFiles();

                foreach (var subdirectory in subDirectories)
                {
                    size += CalculateDirectorySize(subdirectory);
                }

                foreach (var file in files)
                {
                    size += file.Length;
                }
            }
            catch (Exception)
            {
                return 0;
            }

            return size;
        }

    }
}
