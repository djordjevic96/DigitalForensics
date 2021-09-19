using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using System.Windows.Forms;
using System.Data;
using DigitalForensics.ElasticSearch.ElasticSearchModel;
using System.IO;
using System.Threading;
using System.Runtime.ExceptionServices;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json;

namespace DigitalForensics.ElasticSearch.ElasticSearchFunctions
{
    public class ElasticSearchHelperClass
    {
        public static DataTable getAllIndexes()
        {
            if(ConnectionToES.EsClient() != null)
            {
                DataTable dataTable = new DataTable("Indexes");
                dataTable.Columns.Add("Name");

                var result = ConnectionToES.EsClient().Indices.GetAsync(new GetIndexRequest(Indices.All));

                foreach(var x in result.Result.Indices)
                {
                    dataTable.Rows.Add(x.Key);
                }
                return dataTable;
            }
            else
            {
                MessageBox.Show("ElasticSearch is not running", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }          
        }

        public static bool deleteIndex(string indexName)
        {
            var res = ConnectionToES.EsClient().Indices.DeleteAsync(indexName);

            if(res.Result.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DataTable getAllIndexesForPartition(string partition)
        {
            if (ConnectionToES.EsClient() != null)
            {
                DataTable dataTable = new DataTable("Indexes");
                dataTable.Columns.Add("Name");

                var result = ConnectionToES.EsClient().Indices.GetAsync(new GetIndexRequest(Indices.All));

                foreach (var x in result.Result.Indices)
                {
                    if(x.Key.ToString().Contains(partition))
                    {
                        dataTable.Rows.Add(x.Key);
                    }                     
                }
                return dataTable;
            }
            else
            {
                MessageBox.Show("ElasticSearch is not running", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public static void BulkInsert(List<CacheModelES> list, string indexName)
        {
            var bulkAllObservable = ConnectionToES.EsClient().BulkAll(list, b => b
                .Index(indexName)
                .BackOffTime("30s")
                .BackOffRetries(10)
                .RefreshOnCompleted()
                .MaxDegreeOfParallelism(Environment.ProcessorCount)
                .Size(list.Count)
            ).Wait(TimeSpan.FromMinutes(15), next => { });
        }

        public static CacheModelStat prepareForInsert(DirectoryInfo root, List<CacheModelES> data)
        {
            if(root == null)
            {
                return null;
            }
            CacheModelStat result = new CacheModelStat();
            try
            {
                var directories = root.EnumerateDirectories();
                var files = root.EnumerateFiles();

                foreach(var childDirectory in directories)
                {
                    var temp = prepareForInsert(childDirectory,data);

                    result.Size += temp.Size;
                    result.NumberOfFiles += temp.NumberOfFiles;
                }

                foreach(var childFile in files)
                {
                    result.Size += childFile.Length;
                    result.NumberOfFiles++;

                    //var fileRow = data.NewRow();

                    //fileRow["Name"] = childFile.FullName.Replace('\\', '/');
                    //fileRow["Extension"] = childFile.Extension.Split('.')[1];
                    //fileRow["Size"] = childFile.Length;
                    //fileRow["NumberOfFiles"] = 0;
                    //fileRow["CreationTime"] = childFile.CreationTime;
                    //fileRow["LastAccessTime"] = childFile.LastAccessTime;
                    //fileRow["LastModificationTime"] = childFile.LastWriteTime;
                    //fileRow["CacheDate"] = DateTime.Now;

                    //data.Rows.Add(fileRow);
                    data.Add(new CacheModelES {
                        Name = childFile.FullName.Replace('\\', '/'),
                        Extension = childFile.Extension.Split('.')[1],
                        Size = childFile.Length,
                        NumberOfFiles = 0,
                        CreationTime = childFile.CreationTime,
                        LastAccessTime = childFile.LastAccessTime,
                        LastModificationTime = childFile.LastWriteTime,
                        CacheDate = DateTime.Now
                    });
                    
                }
            }
            catch(Exception e)
            {
                //MessageBox.Show(e.ToString());
                return new CacheModelStat();
            }

            //var directoryRow = data.NewRow();

            //directoryRow["Name"] = root.FullName.Replace('\\', '/');
            //directoryRow["Extension"] = "folder";
            //directoryRow["Size"] = result.Size;
            //directoryRow["NumberOfFiles"] = result.NumberOfFiles;
            //directoryRow["CreationTime"] = root.CreationTime;
            //directoryRow["LastAccessTime"] = root.LastAccessTime;
            //directoryRow["LastModificationTime"] = root.LastWriteTime;
            //directoryRow["CacheDate"] = DateTime.Now;

            //data.Rows.Add(directoryRow);
            data.Add(new CacheModelES {
                Name = root.FullName.Replace('\\', '/'),
                Extension = "folder",
                Size = result.Size,
                NumberOfFiles = result.NumberOfFiles,
                CreationTime = root.CreationTime,
                LastAccessTime = root.LastAccessTime,
                LastModificationTime = root.LastWriteTime,
                CacheDate = DateTime.Now
            });
            return result ;
        }


        public static List<List<CacheModelES>> SplitList(List<CacheModelES> listMain, int nSize = 30)
        {
            var list = new List<List<CacheModelES>>();

            for (int i = 0; i < listMain.Count; i += nSize)
            {
                list.Add(listMain.GetRange(i, Math.Min(nSize, listMain.Count - i)));
            }

            return list;
        }
    }
}
