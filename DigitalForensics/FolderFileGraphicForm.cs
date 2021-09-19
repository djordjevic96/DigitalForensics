using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalForensics.ElasticSearch.ElasticSearchFunctions;
using DigitalForensics.ElasticSearch.ElasticSearchModel;

namespace DigitalForensics
{
    public partial class FolderFileGraphicForm : Form
    {
        private DocumentAttributes selectedFile;
        private List<DocumentAttributes> perviousFileData;
        private string selectedDrive;
        private string indexName;
        private List<string> indexNames;
        public enum GraphicOptions
        {
            Size,
            NumberOfFiles,
            TimeAccess,
            TimeModify
        }
        public FolderFileGraphicForm()
        {
            InitializeComponent();
        }

        public FolderFileGraphicForm(string IndexName, string Partition, DocumentAttributes element, List<string> indexNames)
        {
            InitializeComponent();
            this.selectedDrive = Partition;
            this.selectedFile = element;
            this.indexName = IndexName;
            //string id = ElasticSearchQueries.getIDOfDucument(this.indexName, selectedFile.Name, selectedFile.Extension, selectedFile.NumberOfFiles, selectedFile.Size);
            perviousFileData = ElasticSearchQueries.previusData(this.indexNames, selectedFile.Name, selectedFile.Extension, selectedFile.NumberOfFiles, selectedFile.Size);
            selectedFile = perviousFileData.Count == 0 ? selectedFile : perviousFileData.Last();
            ShowDirectoryFileDetails();
            ShowDetailLabels(true);
            cbGraphicOptions.SelectedIndex = 0;
        }

        


        public void ClearChart()
        {
            chart.Series.Clear();
            chart.Titles.Clear();
            foreach (var series in chart.Series)
            {
                series.Points.Clear();
            }
        }

        public void ShowDetailLabels(bool show)
        {
            if (show)
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

        public string DisplayFileSize(long size)
        {
            // Displaying size of files in KB, MB, GB or TB
            var tmp = ((size) / 1024f) / 1024f;
            if (tmp < 1.0)
            {
                return (size) / 1024f + " KB";
            }
            else if (tmp > 1000)
            {
                return (tmp / 1000f) + " GB";
            }
            else if (tmp > 1000000)
            {
                return (tmp / 953674f) + " TB";
            }
            else
            {
                return tmp + " MB";
            }
        }

        
        public void ShowDirectoryFileDetails()
        {
            if (selectedFile.Extension == "folder")
            {
                

                lblFolderFileLabel.Text = "Folder:";
                lblFolderFileName.Text = selectedFile.Name.Split('/').Last();

                lblTypeLabel.Text = "Number of files:";
                lblFolderFileType.Text = selectedFile.NumberOfFiles.ToString();

                lblFolderFileSize.Text = DisplayFileSize(selectedFile.Size);

                lblFolderFileCreated.Text = selectedFile.CreationTime.ToString();
                lblFileFolderLastAccess.Text = selectedFile.LastAccessTime.ToString();
                lblFolderFileLastModify.Text = selectedFile.LastModificationTime.ToString();
            }
            else
            {
                

                lblFolderFileLabel.Text = "File:";
                lblFolderFileName.Text = selectedFile.Name.Split('/').Last();

                lblTypeLabel.Text = "Type:";
                lblFolderFileType.Text = selectedFile.Extension;
                lblFolderFileSize.Text = DisplayFileSize(selectedFile.Size);

                lblFolderFileCreated.Text = selectedFile.CreationTime.ToString();
                lblFileFolderLastAccess.Text = selectedFile.LastAccessTime.ToString();
                lblFolderFileLastModify.Text = selectedFile.LastModificationTime.ToString();
            }
        }

        private void cbGraphicOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch ((GraphicOptions)cbGraphicOptions.SelectedIndex)
                {
                    case GraphicOptions.Size:
                        ClearChart();
                        chart.Titles.Add("Size over 30 days of period (In MB):");
                        var seriesSize = chart.Series.Add("Size");
                        seriesSize.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        seriesSize.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                        seriesSize.MarkerSize = 10;
                        foreach (DocumentAttributes data in perviousFileData)
                        {
                            seriesSize.Points.AddXY(data.CacheDate.ToString().Split('-').ToList().Skip(1).ToList().Aggregate((x, y) => x + "-" + y), (data.Size / 1024f) / 1024f);
                        }
                        foreach (var point in seriesSize.Points)
                        {
                            point.ToolTip = "#VAL";
                        }
                        break;

                    case GraphicOptions.NumberOfFiles:
                        ClearChart();
                        chart.Titles.Add("Number of files for 30 days period:");
                        var seriesFiles = chart.Series.Add("Number Of Files");
                        seriesFiles.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        seriesFiles.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                        seriesFiles.MarkerSize = 10;
                        foreach (DocumentAttributes data in perviousFileData)
                        {
                            seriesFiles.Points.AddXY(data.CacheDate.ToString().Split('-').ToList().Skip(1).ToList().Aggregate((x, y) => x + "-" + y), data.NumberOfFiles);
                        }
                        foreach (var point in seriesFiles.Points)
                        {
                            point.ToolTip = "#VAL";
                        }
                        break;

                    case GraphicOptions.TimeAccess:
                        ClearChart();
                        chart.Titles.Add("Accessing file for 30 days period:");
                        var seriesAccessTime = chart.Series.Add("Time Accessed");
                        seriesAccessTime.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
                        foreach (DocumentAttributes data in perviousFileData)
                        {
                            seriesAccessTime.Points.AddXY(data.CacheDate.ToString().Split('-').ToList().Skip(1).ToList().Aggregate((x, y) => x + "-" + y), data.LastAccessTime);
                        }
                        foreach (var point in seriesAccessTime.Points)
                        {
                            point.ToolTip = "#VAL";
                        }
                        break;

                    case GraphicOptions.TimeModify:
                        ClearChart();
                        chart.Titles.Add("Modification of file for 30 days period:");
                        var seriesModificationTime = chart.Series.Add("Modification time");
                        seriesModificationTime.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
                        foreach (DocumentAttributes data in perviousFileData)
                        {
                            seriesModificationTime.Points.AddXY(data.CacheDate.ToString().Split('-').ToList().Skip(1).ToList().Aggregate((x, y) => x + "-" + y), data.LastAccessTime);
                        }
                        foreach (var point in seriesModificationTime.Points)
                        {
                            point.ToolTip = "#VAL";
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
