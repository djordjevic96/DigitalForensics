using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalForensics.Models;
using DigitalForensics.HelperClass;
using DigitalForensics.ElasticSearch.ElasticSearchModel;
using DigitalForensics.ElasticSearch.ElasticSearchFunctions;


namespace DigitalForensics
{
    public partial class FileSystemAnalysis : Form
    {
        //private string namePartition;
        private readonly FileSystemManipulationClass filesManipunation;
        private DisplayCacheModelES forDisplayModel;
        private List<string> indexesNames;
       

        public FileSystemAnalysis()
        {
            InitializeComponent();
            filesManipunation = new FileSystemManipulationClass();
            lblCacheProcess.Visible = false;
            pbCaching.Visible = false;
            indexesNames = new List<string>();
            
        }

        private void FileSystemAnalysis_Load(object sender, EventArgs e)
        {
            setPartitions();
            FileTV1.TreeViewNodeSorter = new TreeNodeSorting();

            
                var res = ElasticSearch.ConnectionToES.EsClient().Ping();

                if (res.IsValid)
                {
                    lblElasticSearchInformation.Visible = true;
                    lblElasticSearchInformation.Text = "Elasticsearch is running....";
                    lblElasticSearchInformation.ForeColor = Color.Black;
                btnDeleteSelectedIndex.Enabled = true;
                    showCacheInformation();
                }
                else
                {
                    lblElasticSearchInformation.Visible = true;
                btnCache.Enabled = false;
                btnDeleteSelectedIndex.Enabled = false;
                lblElasticSearchInformation.Text = "Elasticsearch is not running....";
                    lblElasticSearchInformation.ForeColor = Color.Red;
                }
            

                 
        }

        public void showCacheInformation()
        {
           
            DataTable retDataTable = ElasticSearchHelperClass.getAllIndexes();
            if (retDataTable != null)
            {
                dataGridView1.DataSource = retDataTable;
                for (int i = 0; i < retDataTable.Rows.Count; i++)
                {
                    indexesNames.Add(retDataTable.Rows[i]["Name"].ToString());
                }
            }
        }

        private void setPartitions()
        {
            string lastSelectedDriver = cbPartitions.SelectedItem?.ToString();
            var drivers = Directory.GetLogicalDrives();
            cbPartitions.Items.Clear();
            cbPartitions.Items.AddRange(drivers.Select(x => x.ToString()).ToArray());

            if (!String.IsNullOrEmpty(lastSelectedDriver))
            {
                cbPartitions.SelectedItem = lastSelectedDriver;
            }
            else
            {
                cbPartitions.SelectedIndex = 0;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFileTree();
                PartitionChartView();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error : ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void PartitionChartView()
        {
            DriveInfo df = new DriveInfo(cbPartitions.SelectedItem.ToString());

            foreach(var series in PartitionChart.Series)
            {
                series.Points.Clear();
            }

            long directorySpace = df.TotalSize;
            long freeSpace = df.TotalFreeSpace;

            long usedSpace = directorySpace - freeSpace;

            PartitionChart.Series["s1"]["PieLabelStyle"] = "Disabled";
            

            PartitionChart.Series["s1"].Points.AddXY("Free Space: " + DisplayFileSize(freeSpace), freeSpace);
            PartitionChart.Series["s1"].Points.AddXY("Used Space: " + DisplayFileSize(usedSpace), directorySpace - freeSpace);
        }

        public bool checkIfDatesCacheInElasticSearchForSpecificPartition(string partition)
        {
            bool ret = false;
            if (dataGridView1.Rows.Count > 0)
            {
                
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {
                    if(row.Cells["Name"].Value.ToString().Contains(partition.Substring(0, 1).ToLower()))
                    {
                        ret = true;
                    }
                }
            }
            return ret;
        }

        public void CheckForCache()
        {
            var res = ElasticSearch.ConnectionToES.EsClient().Ping();

            if(res.IsValid)
            {
                if (checkIfDatesCacheInElasticSearchForSpecificPartition(cbPartitions.SelectedItem.ToString()))
                {
                    DialogResult dlg = MessageBox.Show("You have already cache data\n Do you want to cache data now?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dlg == DialogResult.Yes)
                    {
                        btnCache.PerformClick();
                    }
                }
            }
            else
            {
                btnCache.Enabled = false;
                MessageBox.Show("Elasticsearch is not running...", "Information", MessageBoxButtons.OK,MessageBoxIcon.Error);
                lblElasticSearchInformation.Visible = true;
                lblElasticSearchInformation.Text = "Elasticsearch is not running....";
                lblElasticSearchInformation.ForeColor = Color.Red;
            }
        }

        public void CheckCacheInformation()
        {
            //bool ret = false;
            var res = ElasticSearch.ConnectionToES.EsClient().Ping();

            if (res.IsValid)
            {
                lblElasticSearchInformation.Visible = true;
                btnCache.Enabled = true;
                lblElasticSearchInformation.Text = "Elasticsearch is running....";
                lblElasticSearchInformation.ForeColor = Color.Black;
                showCacheInformation();
                
            }
            else
            {
                btnCache.Enabled = false;
                MessageBox.Show("Elasticsearch is not running...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblElasticSearchInformation.Visible = true;
                lblElasticSearchInformation.Text = "Elasticsearch is not running....";
                lblElasticSearchInformation.ForeColor = Color.Red;
            }
            
        }

        public async void LoadFileTree()
        {
            btnSearch.Enabled = false;
            FileTV1.Nodes.Clear();
            cbPartitions.Enabled = false;
            ShowDetailLabels(false);


            string selectDrive = cbPartitions.SelectedItem.ToString();
            

            DirectoryNodeTV rootNode = new DirectoryNodeTV(selectDrive)
            {
                Tag = new DirectoryInfo(selectDrive)
            };

            var childs = await Task.Run(() => filesManipunation.GetDirectoryChilds(selectDrive));

            if(childs.Error == null)
            {
                FileTV1.BeginUpdate();
                rootNode.Nodes.AddRange(childs.ChildNodes.ToArray());
                FileTV1.Nodes.Add(rootNode);
                FileTV1.Nodes[0].Expand();

                FileTV1.EndUpdate();

                
                //CheckForCache();

            }
            else
            {
                MessageBox.Show("Error occured while trying to get files. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            btnSearch.Enabled = true;
            cbPartitions.Enabled = true;
        }




        private void FileTV1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var expandNode = e.Node as DirectoryNodeTV;
            if(!expandNode.Expanded)
            {
                FileTV1.BeginUpdate();
                e.Node.Nodes.Clear();
                var children = filesManipunation.GetDirectoryChilds((expandNode.Tag as DirectoryInfo).FullName);

                if(children.Error == null && children.ChildNodes.Count !=0)
                {
                    e.Node.Nodes.AddRange(children.ChildNodes.ToArray());
                    expandNode.Expanded = true;
                }
                else if(children.Error !=null)
                {
                    e.Node.ForeColor = Color.Red;
                    if(children.Error is UnauthorizedAccessException)
                    {
                        e.Node.Text += " (Unauthorized Access Error)";
                    }
                    else
                    {
                        e.Node.Text += " (Unknow Error Occured)";
                    }
                }
                FileTV1.EndUpdate();
            }
        }

        private void FileTV1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedNode = FileTV1.SelectedNode;
            if(selectedNode == null)
            {
                return;
            }
            if(selectedNode is DirectoryNodeTV)
            {
                ShowDirectoryOrFileInformation(true,selectedNode);
                btnShowStatistics.Visible = true;
            }
            else
            {
                ShowDirectoryOrFileInformation(false,selectedNode);
                btnShowStatistics.Visible = true;
            }

        }

        public async void ShowDirectoryOrFileInformation(bool isDirectory, TreeNode selectedNode)
        {
            if(isDirectory)
            {
                ShowDetailLabels(true);
                var dirInfo = selectedNode.Tag as DirectoryInfo;
                var directoryNode = selectedNode as DirectoryNodeTV;


                lblFolderFileLabel.Text = "Folder:";
                lblFolderFileName.Text = dirInfo.Name;

                lblTypeLabel.Text = "Number of files:";
                lblFolderFileType.Text = "...";

                lblFolderFileSize.Text = "...";
                lblFolderFileCreated.Text = dirInfo.CreationTime.ToString();
                lblFileFolderLastAccess.Text = dirInfo.LastAccessTime.ToString();
                lblFolderFileLastModify.Text = dirInfo.LastWriteTime.ToString();

                if(!directoryNode.NumberOfFilesCalculated)
                {
                    directoryNode.NumberOfFiles = await Task.Run(() => filesManipunation.CalculateNumberOfFiles(dirInfo));
                    directoryNode.NumberOfFilesCalculated = true;
                }
                lblFolderFileType.Text = directoryNode.NumberOfFiles.ToString();

                if (!directoryNode.SizeCalculate)
                {
                    directoryNode.Size = await Task.Run(() => filesManipunation.CalculateDirectorySize(dirInfo));
                    directoryNode.SizeCalculate = true;
                }
                lblFolderFileSize.Text = DisplayFileSize(directoryNode.Size);
            }
            else
            {
                ShowDetailLabels(false);
                var fileInfo = selectedNode.Tag as FileInfo;

                lblFolderFileLabel.Text = "File:";
                lblFolderFileName.Text = fileInfo.Name;

                lblTypeLabel.Text = "Type:";
                lblFolderFileType.Text = fileInfo.Extension;
                lblFolderFileSize.Text = DisplayFileSize(fileInfo.Length);

                lblFolderFileCreated.Text = fileInfo.CreationTime.ToString();
                lblFileFolderLastAccess.Text = fileInfo.LastAccessTime.ToString();
                lblFolderFileLastModify.Text = fileInfo.LastWriteTime.ToString();
            }

        }

        public string DisplayFileSize(long size)
        {
            var tmp = ((size) / 1024f) / 1024f;
            if(tmp<1.0)
            {
                return Math.Round((size) / 1024f,2) + " KB";
            }
            else if(tmp>1000)
            {
                return Math.Round((tmp / 1000f),2) + " GB";
            }
            else if (tmp > 1000000)
            {
                return Math.Round((tmp / 953674f),2) + " TB";
            }
            else
            {
                return Math.Round(tmp,2) + " MB";
            }
        }

        public void ShowDetailLabels(bool show)
        {
            if(show)
            {
                lblFolderFileName.Visible = true;
                lblFolderFileType.Visible = true;
                lblFolderFileSize.Visible = true;
                lblFolderFileCreated.Visible = true;
                lblFileFolderLastAccess.Visible = true;
                lblFolderFileLastModify.Visible = true;
            }
            else
            {
                lblFolderFileName.Visible = false;
                lblFolderFileType.Visible = false;
                lblFolderFileSize.Visible = false;
                lblFolderFileCreated.Visible = false;
                lblFileFolderLastAccess.Visible = false;
                lblFolderFileLastModify.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblCacheProcess.Visible = true;
            pbCaching.Visible = true;

            string partitionName =  cbPartitions.SelectedItem.ToString().Substring(0, 1).ToLower() + "" + DateTime.Now.Day+""+DateTime.Now.Month+""+DateTime.Now.Year+""+DateTime.Now.Hour;
            string partition = cbPartitions.SelectedItem.ToString();

            var worker = new BackgroundWorker();
            worker.DoWork += (s, args) =>
            {
                
                string indexName = partitionName.ToLower().Replace(" ","");
                List<CacheModelES> listForInsert = new List<CacheModelES>();

                
                var rootSize = ElasticSearchHelperClass.prepareForInsert(new DirectoryInfo(partition), listForInsert);
                List<List<CacheModelES>> listSplitsForIndexing = new List<List<CacheModelES>>();
                listSplitsForIndexing = ElasticSearchHelperClass.SplitList(listForInsert, 2000);
                foreach(List<CacheModelES> lists in listSplitsForIndexing)
                {
                    ElasticSearchHelperClass.BulkInsert(lists, indexName);
                }    
                
            };
            worker.RunWorkerCompleted += (s, args) =>
            {
                lblCacheProcess.Visible = false;
                pbCaching.Visible = false;
                showCacheInformation();
            };

            worker.RunWorkerAsync();
            
        }

        private void cbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(FileTV1.Nodes.Count !=0)
            {
                ShowDetailLabels(false);
                SortTreeView();
            }
        }

       
        //Sort Tree View()
        public void SortTreeView()
        {
            switch (cbSortBy.SelectedIndex)
            {
                case 0:
                    //Sort by Name Ascending
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).SortMethod = SortBy.Name;
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).Desc = false;
                    FileTV1.Sort();
                    break;
                case 1:
                    //Sort By Name Descending
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).SortMethod = SortBy.Name;
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).Desc = true;
                    FileTV1.Sort();
                    break;
                case 2:
                    //Sort by Size Acending
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).SortMethod = SortBy.Size;
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).Desc = false;
                    FileTV1.Sort();
                    break;
                case 3:
                    //Sort by Size Descending
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).SortMethod = SortBy.Size;
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).Desc = true;
                    FileTV1.Sort();
                    break;
                case 4:
                    //Sort by Number of files Ascending
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).SortMethod = SortBy.NumberOfFiles;
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).Desc = false;
                    FileTV1.Sort();
                    break;
                case 5:
                    //Sort by Number of Files Descending
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).SortMethod = SortBy.NumberOfFiles;
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).Desc = true;
                    FileTV1.Sort();
                    break;
                case 6:
                    // Sort by Time Created Ascending
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).SortMethod = SortBy.TimeCreated;
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).Desc = false;
                    FileTV1.Sort();
                    break;
                case 7:
                    //Sort by Time Created Descending
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).SortMethod = SortBy.TimeCreated;
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).Desc = true;
                    FileTV1.Sort();
                    break;
                case 8:
                    //Sort by Last Write Ascending
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).SortMethod = SortBy.TimeLastModified;
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).Desc = false;
                    FileTV1.Sort();
                    break;
                case 9:
                    //Sort by Last Write Descending
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).SortMethod = SortBy.TimeLastModified;
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).Desc = true;
                    FileTV1.Sort();
                    break;
                case 10:
                    //Sort by Last Access Ascending
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).SortMethod = SortBy.TimeLastAccessed;
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).Desc = false;
                    FileTV1.Sort();
                    break;
                case 11:
                    //Sort by Last Access Ascending
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).SortMethod = SortBy.TimeLastAccessed;
                    (FileTV1.TreeViewNodeSorter as TreeNodeSorting).Desc = true;
                    FileTV1.Sort();
                    break;
                default:
                    break;

            }

        }

        private void btnShowStatistics_Click(object sender, EventArgs e)
        {
           
            var selectedNode = FileTV1.SelectedNode;
            if(selectedNode == null)
            {
                return;
            }

            if(selectedNode is DirectoryNodeTV)
            {
                var info = selectedNode.Tag as DirectoryInfo;

                forDisplayModel = new DisplayCacheModelES()
                {
                    CreationTime = info.CreationTime,
                    Extension = "folder",
                    LastAccessTime = info.LastAccessTime,
                    LastModificationTime = info.LastWriteTime,
                    Name = info.FullName.Replace('\\', '/'),
                    NumberOfFiles = (selectedNode as DirectoryNodeTV).NumberOfFiles,
                    Size = (selectedNode as DirectoryNodeTV).Size
                };

                if (ElasticSearch.ConnectionToES.EsClient().Ping().IsValid)
                {

                    string partition = cbPartitions.SelectedItem.ToString().Substring(0, 1).ToLower();
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string indexName = Convert.ToString(selectedRow.Cells["Name"].Value);

                    List<string> listForForm = new List<string>();
                    foreach(string s in indexesNames)
                    {
                        if(s.Contains(partition))
                        {
                            listForForm.Add(s);
                        }
                    }


                
                    Form formNew = new FolderFileGraphicForm(indexName, partition, new DocumentAttributes
                    {
                        CacheDate = forDisplayModel.CacheDate,
                        CreationTime = forDisplayModel.CreationTime,
                        Extension = forDisplayModel.Extension,
                        LastAccessTime = forDisplayModel.LastAccessTime,
                        LastModificationTime = forDisplayModel.LastModificationTime,
                        Name = forDisplayModel.Name,
                        NumberOfFiles = forDisplayModel.NumberOfFiles,
                        Size = forDisplayModel.Size
                    }, indexesNames);
                    formNew.Show();
                }
                else
                {
                    MessageBox.Show("Please chek elasticsearch", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                var info = selectedNode.Tag as FileInfo;

                forDisplayModel = new DisplayCacheModelES()
                {
                    CreationTime = info.CreationTime,
                    Extension = info.Extension.Split('.')[1],
                    LastAccessTime = info.LastAccessTime,
                    LastModificationTime = info.LastWriteTime,
                    Name = info.FullName.Replace('\\','/'),
                    NumberOfFiles = 0,
                    Size = info.Length
                };

                if (ElasticSearch.ConnectionToES.EsClient().Ping().IsValid)
                {

                    string partition = cbPartitions.SelectedItem.ToString().Substring(0, 1).ToLower();
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string indexName = Convert.ToString(selectedRow.Cells["Name"].Value);

                    List<string> listForForm = new List<string>();
                    foreach (string s in indexesNames)
                    {
                        if (s.Contains(partition))
                        {
                            listForForm.Add(s);
                        }
                    }

               
                    Form formNew = new FolderFileGraphicForm(indexName, partition, new DocumentAttributes
                    {
                        CacheDate = forDisplayModel.CacheDate,
                        CreationTime = forDisplayModel.CreationTime,
                        Extension = forDisplayModel.Extension,
                        LastAccessTime = forDisplayModel.LastAccessTime,
                        LastModificationTime = forDisplayModel.LastModificationTime,
                        Name = forDisplayModel.Name,
                        NumberOfFiles = forDisplayModel.NumberOfFiles,
                        Size = forDisplayModel.Size
                    }, indexesNames);
                    formNew.Show();
                }
                else
                {
                    MessageBox.Show("Please chek elasticsearch", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
        }

       

        public void SaveIndexNames()
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                indexesNames.Add(row.Cells["Name"].Value.ToString());
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            var res = ElasticSearch.ConnectionToES.EsClient().Ping();

            if (res.IsValid)
            {

                Form filterForm = new Filter_Form(cbPartitions.SelectedItem.ToString().Substring(0, 1).ToLower());
                filterForm.Show();
                
               
            }
            else
            {
                MessageBox.Show("Please chek elasticsearch","Warning",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            

        }

        private void btnCheckCacheInformation_Click(object sender, EventArgs e)
        {
            CheckCacheInformation();

        }

        private void btnDeleteSelectedIndex_Click(object sender, EventArgs e)
        {
            if(ElasticSearch.ConnectionToES.EsClient().Ping().IsValid)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string indexName = Convert.ToString(selectedRow.Cells["Name"].Value);
                if (ElasticSearchHelperClass.deleteIndex(indexName))
                {
                    MessageBox.Show("Index is deleted ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

            }
        }
    }
}
