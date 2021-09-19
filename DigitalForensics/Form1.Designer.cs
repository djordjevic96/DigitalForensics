
namespace DigitalForensics
{
    partial class FileSystemAnalysis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSystemAnalysis));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbPartitions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.FileTV1 = new System.Windows.Forms.TreeView();
            this.PartitionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbPartitionInformation = new System.Windows.Forms.GroupBox();
            this.pnlFolderDetails = new System.Windows.Forms.Panel();
            this.btnShowStatistics = new System.Windows.Forms.Button();
            this.lblFolderFileType = new System.Windows.Forms.Label();
            this.lblTypeLabel = new System.Windows.Forms.Label();
            this.lblFolderFileLastModify = new System.Windows.Forms.Label();
            this.lblLastModifyLabel = new System.Windows.Forms.Label();
            this.lblFileFolderLastAccess = new System.Windows.Forms.Label();
            this.lblLastAccessLabel = new System.Windows.Forms.Label();
            this.lblFolderFileCreated = new System.Windows.Forms.Label();
            this.lblCreatedLabel = new System.Windows.Forms.Label();
            this.lblFolderFileSize = new System.Windows.Forms.Label();
            this.lblSizeLabel = new System.Windows.Forms.Label();
            this.lblFolderFileName = new System.Windows.Forms.Label();
            this.lblFolderFileLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblElasticSearchInformation = new System.Windows.Forms.Label();
            this.btnCheckCacheInformation = new System.Windows.Forms.Button();
            this.pbCaching = new System.Windows.Forms.PictureBox();
            this.lblCacheProcess = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCache = new System.Windows.Forms.Button();
            this.lblSortBy = new System.Windows.Forms.Label();
            this.cbSortBy = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnDeleteSelectedIndex = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PartitionChart)).BeginInit();
            this.gbPartitionInformation.SuspendLayout();
            this.pnlFolderDetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaching)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPartitions
            // 
            this.cbPartitions.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cbPartitions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbPartitions.ForeColor = System.Drawing.SystemColors.Window;
            this.cbPartitions.FormattingEnabled = true;
            this.cbPartitions.Location = new System.Drawing.Point(65, 38);
            this.cbPartitions.Name = "cbPartitions";
            this.cbPartitions.Size = new System.Drawing.Size(92, 21);
            this.cbPartitions.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Partitions";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSearch.Location = new System.Drawing.Point(173, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 21);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FileTV1
            // 
            this.FileTV1.Location = new System.Drawing.Point(705, 51);
            this.FileTV1.Name = "FileTV1";
            this.FileTV1.Size = new System.Drawing.Size(447, 472);
            this.FileTV1.TabIndex = 3;
            this.FileTV1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.FileTV1_BeforeExpand);
            this.FileTV1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FileTV1_AfterSelect);
            // 
            // PartitionChart
            // 
            chartArea2.Name = "ChartArea1";
            this.PartitionChart.ChartAreas.Add(chartArea2);
            legend2.AutoFitMinFontSize = 5;
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.IsTextAutoFit = false;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend2.Name = "Legend1";
            this.PartitionChart.Legends.Add(legend2);
            this.PartitionChart.Location = new System.Drawing.Point(6, 29);
            this.PartitionChart.Name = "PartitionChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "s1";
            this.PartitionChart.Series.Add(series2);
            this.PartitionChart.Size = new System.Drawing.Size(414, 336);
            this.PartitionChart.TabIndex = 4;
            this.PartitionChart.Text = "chart1";
            title2.Name = "Partition information";
            this.PartitionChart.Titles.Add(title2);
            // 
            // gbPartitionInformation
            // 
            this.gbPartitionInformation.Controls.Add(this.PartitionChart);
            this.gbPartitionInformation.Location = new System.Drawing.Point(273, 136);
            this.gbPartitionInformation.Name = "gbPartitionInformation";
            this.gbPartitionInformation.Size = new System.Drawing.Size(426, 387);
            this.gbPartitionInformation.TabIndex = 5;
            this.gbPartitionInformation.TabStop = false;
            this.gbPartitionInformation.Text = "Partition Information";
            // 
            // pnlFolderDetails
            // 
            this.pnlFolderDetails.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pnlFolderDetails.Controls.Add(this.btnShowStatistics);
            this.pnlFolderDetails.Controls.Add(this.lblFolderFileType);
            this.pnlFolderDetails.Controls.Add(this.lblTypeLabel);
            this.pnlFolderDetails.Controls.Add(this.lblFolderFileLastModify);
            this.pnlFolderDetails.Controls.Add(this.lblLastModifyLabel);
            this.pnlFolderDetails.Controls.Add(this.lblFileFolderLastAccess);
            this.pnlFolderDetails.Controls.Add(this.lblLastAccessLabel);
            this.pnlFolderDetails.Controls.Add(this.lblFolderFileCreated);
            this.pnlFolderDetails.Controls.Add(this.lblCreatedLabel);
            this.pnlFolderDetails.Controls.Add(this.lblFolderFileSize);
            this.pnlFolderDetails.Controls.Add(this.lblSizeLabel);
            this.pnlFolderDetails.Controls.Add(this.lblFolderFileName);
            this.pnlFolderDetails.Controls.Add(this.lblFolderFileLabel);
            this.pnlFolderDetails.Location = new System.Drawing.Point(273, 12);
            this.pnlFolderDetails.Name = "pnlFolderDetails";
            this.pnlFolderDetails.Size = new System.Drawing.Size(426, 118);
            this.pnlFolderDetails.TabIndex = 15;
            // 
            // btnShowStatistics
            // 
            this.btnShowStatistics.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnShowStatistics.Location = new System.Drawing.Point(9, 88);
            this.btnShowStatistics.Name = "btnShowStatistics";
            this.btnShowStatistics.Size = new System.Drawing.Size(27, 23);
            this.btnShowStatistics.TabIndex = 23;
            this.btnShowStatistics.Text = "🖻 ";
            this.btnShowStatistics.UseVisualStyleBackColor = true;
            this.btnShowStatistics.Visible = false;
            this.btnShowStatistics.Click += new System.EventHandler(this.btnShowStatistics_Click);
            // 
            // lblFolderFileType
            // 
            this.lblFolderFileType.AutoSize = true;
            this.lblFolderFileType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileType.Location = new System.Drawing.Point(118, 63);
            this.lblFolderFileType.Name = "lblFolderFileType";
            this.lblFolderFileType.Size = new System.Drawing.Size(29, 15);
            this.lblFolderFileType.TabIndex = 11;
            this.lblFolderFileType.Text = "type";
            this.lblFolderFileType.Visible = false;
            // 
            // lblTypeLabel
            // 
            this.lblTypeLabel.AutoSize = true;
            this.lblTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeLabel.Location = new System.Drawing.Point(14, 63);
            this.lblTypeLabel.Name = "lblTypeLabel";
            this.lblTypeLabel.Size = new System.Drawing.Size(41, 15);
            this.lblTypeLabel.TabIndex = 10;
            this.lblTypeLabel.Text = "Type:";
            // 
            // lblFolderFileLastModify
            // 
            this.lblFolderFileLastModify.AutoSize = true;
            this.lblFolderFileLastModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileLastModify.Location = new System.Drawing.Point(305, 91);
            this.lblFolderFileLastModify.Name = "lblFolderFileLastModify";
            this.lblFolderFileLastModify.Size = new System.Drawing.Size(65, 15);
            this.lblFolderFileLastModify.TabIndex = 9;
            this.lblFolderFileLastModify.Text = "last modify";
            this.lblFolderFileLastModify.Visible = false;
            // 
            // lblLastModifyLabel
            // 
            this.lblLastModifyLabel.AutoSize = true;
            this.lblLastModifyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastModifyLabel.Location = new System.Drawing.Point(175, 91);
            this.lblLastModifyLabel.Name = "lblLastModifyLabel";
            this.lblLastModifyLabel.Size = new System.Drawing.Size(84, 15);
            this.lblLastModifyLabel.TabIndex = 8;
            this.lblLastModifyLabel.Text = "Last modify:";
            // 
            // lblFileFolderLastAccess
            // 
            this.lblFileFolderLastAccess.AutoSize = true;
            this.lblFileFolderLastAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileFolderLastAccess.Location = new System.Drawing.Point(305, 63);
            this.lblFileFolderLastAccess.Name = "lblFileFolderLastAccess";
            this.lblFileFolderLastAccess.Size = new System.Drawing.Size(67, 15);
            this.lblFileFolderLastAccess.TabIndex = 7;
            this.lblFileFolderLastAccess.Text = "last access";
            this.lblFileFolderLastAccess.Visible = false;
            // 
            // lblLastAccessLabel
            // 
            this.lblLastAccessLabel.AutoSize = true;
            this.lblLastAccessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastAccessLabel.Location = new System.Drawing.Point(175, 63);
            this.lblLastAccessLabel.Name = "lblLastAccessLabel";
            this.lblLastAccessLabel.Size = new System.Drawing.Size(86, 15);
            this.lblLastAccessLabel.TabIndex = 6;
            this.lblLastAccessLabel.Text = "Last access:";
            // 
            // lblFolderFileCreated
            // 
            this.lblFolderFileCreated.AutoSize = true;
            this.lblFolderFileCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileCreated.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblFolderFileCreated.Location = new System.Drawing.Point(305, 39);
            this.lblFolderFileCreated.Name = "lblFolderFileCreated";
            this.lblFolderFileCreated.Size = new System.Drawing.Size(48, 15);
            this.lblFolderFileCreated.TabIndex = 5;
            this.lblFolderFileCreated.Text = "created";
            this.lblFolderFileCreated.Visible = false;
            // 
            // lblCreatedLabel
            // 
            this.lblCreatedLabel.AutoSize = true;
            this.lblCreatedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedLabel.Location = new System.Drawing.Point(200, 39);
            this.lblCreatedLabel.Name = "lblCreatedLabel";
            this.lblCreatedLabel.Size = new System.Drawing.Size(61, 15);
            this.lblCreatedLabel.TabIndex = 4;
            this.lblCreatedLabel.Text = "Created:";
            // 
            // lblFolderFileSize
            // 
            this.lblFolderFileSize.AutoSize = true;
            this.lblFolderFileSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileSize.Location = new System.Drawing.Point(117, 39);
            this.lblFolderFileSize.Name = "lblFolderFileSize";
            this.lblFolderFileSize.Size = new System.Drawing.Size(29, 15);
            this.lblFolderFileSize.TabIndex = 3;
            this.lblFolderFileSize.Text = "size";
            this.lblFolderFileSize.Visible = false;
            // 
            // lblSizeLabel
            // 
            this.lblSizeLabel.AutoSize = true;
            this.lblSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeLabel.Location = new System.Drawing.Point(16, 39);
            this.lblSizeLabel.Name = "lblSizeLabel";
            this.lblSizeLabel.Size = new System.Drawing.Size(39, 15);
            this.lblSizeLabel.TabIndex = 2;
            this.lblSizeLabel.Text = "Size:";
            // 
            // lblFolderFileName
            // 
            this.lblFolderFileName.AutoSize = true;
            this.lblFolderFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileName.Location = new System.Drawing.Point(116, 14);
            this.lblFolderFileName.Name = "lblFolderFileName";
            this.lblFolderFileName.Size = new System.Drawing.Size(42, 16);
            this.lblFolderFileName.TabIndex = 1;
            this.lblFolderFileName.Text = "name";
            this.lblFolderFileName.Visible = false;
            // 
            // lblFolderFileLabel
            // 
            this.lblFolderFileLabel.AutoSize = true;
            this.lblFolderFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileLabel.Location = new System.Drawing.Point(13, 11);
            this.lblFolderFileLabel.Name = "lblFolderFileLabel";
            this.lblFolderFileLabel.Size = new System.Drawing.Size(99, 20);
            this.lblFolderFileLabel.TabIndex = 0;
            this.lblFolderFileLabel.Text = "Folder/File:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteSelectedIndex);
            this.groupBox1.Controls.Add(this.lblElasticSearchInformation);
            this.groupBox1.Controls.Add(this.btnCheckCacheInformation);
            this.groupBox1.Controls.Add(this.pbCaching);
            this.groupBox1.Controls.Add(this.lblCacheProcess);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.btnCache);
            this.groupBox1.Location = new System.Drawing.Point(9, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 387);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cache information";
            // 
            // lblElasticSearchInformation
            // 
            this.lblElasticSearchInformation.AutoSize = true;
            this.lblElasticSearchInformation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblElasticSearchInformation.Location = new System.Drawing.Point(53, 352);
            this.lblElasticSearchInformation.Name = "lblElasticSearchInformation";
            this.lblElasticSearchInformation.Size = new System.Drawing.Size(145, 13);
            this.lblElasticSearchInformation.TabIndex = 20;
            this.lblElasticSearchInformation.Text = "Elasticsearch is not running...";
            this.lblElasticSearchInformation.Visible = false;
            // 
            // btnCheckCacheInformation
            // 
            this.btnCheckCacheInformation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCheckCacheInformation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCheckCacheInformation.Location = new System.Drawing.Point(145, 293);
            this.btnCheckCacheInformation.Name = "btnCheckCacheInformation";
            this.btnCheckCacheInformation.Size = new System.Drawing.Size(94, 23);
            this.btnCheckCacheInformation.TabIndex = 18;
            this.btnCheckCacheInformation.Text = "Check cache";
            this.btnCheckCacheInformation.UseVisualStyleBackColor = true;
            this.btnCheckCacheInformation.Click += new System.EventHandler(this.btnCheckCacheInformation_Click);
            // 
            // pbCaching
            // 
            this.pbCaching.Image = ((System.Drawing.Image)(resources.GetObject("pbCaching.Image")));
            this.pbCaching.Location = new System.Drawing.Point(168, 32);
            this.pbCaching.Name = "pbCaching";
            this.pbCaching.Size = new System.Drawing.Size(44, 45);
            this.pbCaching.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCaching.TabIndex = 17;
            this.pbCaching.TabStop = false;
            // 
            // lblCacheProcess
            // 
            this.lblCacheProcess.AutoSize = true;
            this.lblCacheProcess.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCacheProcess.Location = new System.Drawing.Point(33, 46);
            this.lblCacheProcess.Name = "lblCacheProcess";
            this.lblCacheProcess.Size = new System.Drawing.Size(87, 13);
            this.lblCacheProcess.TabIndex = 5;
            this.lblCacheProcess.Text = "Cache process...";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 83);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.Size = new System.Drawing.Size(226, 194);
            this.dataGridView1.TabIndex = 5;
            // 
            // btnCache
            // 
            this.btnCache.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCache.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCache.Location = new System.Drawing.Point(13, 293);
            this.btnCache.Name = "btnCache";
            this.btnCache.Size = new System.Drawing.Size(75, 23);
            this.btnCache.TabIndex = 16;
            this.btnCache.Text = "Cache now";
            this.btnCache.UseVisualStyleBackColor = true;
            this.btnCache.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblSortBy
            // 
            this.lblSortBy.AutoSize = true;
            this.lblSortBy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSortBy.Location = new System.Drawing.Point(823, 20);
            this.lblSortBy.Name = "lblSortBy";
            this.lblSortBy.Size = new System.Drawing.Size(43, 13);
            this.lblSortBy.TabIndex = 16;
            this.lblSortBy.Text = "Sort by:";
            // 
            // cbSortBy
            // 
            this.cbSortBy.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cbSortBy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSortBy.ForeColor = System.Drawing.SystemColors.Window;
            this.cbSortBy.FormattingEnabled = true;
            this.cbSortBy.Items.AddRange(new object[] {
            "Name Ascending",
            "Name Descending",
            "Size Ascending",
            "Size Descending",
            "Number of Files Ascending",
            "Number of Files Descending",
            "Time Created Ascending",
            "Time Created Descending",
            "Last Write Ascending",
            "Last Write Descending",
            "Last Access Ascending",
            "Last Access Descending"});
            this.cbSortBy.Location = new System.Drawing.Point(889, 17);
            this.cbSortBy.Name = "cbSortBy";
            this.cbSortBy.Size = new System.Drawing.Size(132, 21);
            this.cbSortBy.TabIndex = 18;
            this.cbSortBy.SelectedIndexChanged += new System.EventHandler(this.cbSortBy_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStatistics);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbPartitions);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Location = new System.Drawing.Point(9, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 118);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Partitions";
            // 
            // btnStatistics
            // 
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStatistics.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStatistics.Location = new System.Drawing.Point(65, 83);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(92, 23);
            this.btnStatistics.TabIndex = 17;
            this.btnStatistics.Text = "Filter data";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnDeleteSelectedIndex
            // 
            this.btnDeleteSelectedIndex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteSelectedIndex.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteSelectedIndex.Location = new System.Drawing.Point(65, 322);
            this.btnDeleteSelectedIndex.Name = "btnDeleteSelectedIndex";
            this.btnDeleteSelectedIndex.Size = new System.Drawing.Size(92, 23);
            this.btnDeleteSelectedIndex.TabIndex = 21;
            this.btnDeleteSelectedIndex.Text = "Delete index";
            this.btnDeleteSelectedIndex.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedIndex.Click += new System.EventHandler(this.btnDeleteSelectedIndex_Click);
            // 
            // FileSystemAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1176, 535);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbSortBy);
            this.Controls.Add(this.lblSortBy);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pnlFolderDetails);
            this.Controls.Add(this.gbPartitionInformation);
            this.Controls.Add(this.FileTV1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileSystemAnalysis";
            this.Text = "File system Analysis";
            this.Load += new System.EventHandler(this.FileSystemAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PartitionChart)).EndInit();
            this.gbPartitionInformation.ResumeLayout(false);
            this.pnlFolderDetails.ResumeLayout(false);
            this.pnlFolderDetails.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaching)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPartitions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TreeView FileTV1;
        private System.Windows.Forms.DataVisualization.Charting.Chart PartitionChart;
        private System.Windows.Forms.GroupBox gbPartitionInformation;
        private System.Windows.Forms.Panel pnlFolderDetails;
        private System.Windows.Forms.Button btnShowStatistics;
        private System.Windows.Forms.Label lblFolderFileType;
        private System.Windows.Forms.Label lblTypeLabel;
        private System.Windows.Forms.Label lblFolderFileLastModify;
        private System.Windows.Forms.Label lblLastModifyLabel;
        private System.Windows.Forms.Label lblFileFolderLastAccess;
        private System.Windows.Forms.Label lblLastAccessLabel;
        private System.Windows.Forms.Label lblFolderFileCreated;
        private System.Windows.Forms.Label lblCreatedLabel;
        private System.Windows.Forms.Label lblFolderFileSize;
        private System.Windows.Forms.Label lblSizeLabel;
        private System.Windows.Forms.Label lblFolderFileName;
        private System.Windows.Forms.Label lblFolderFileLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbCaching;
        private System.Windows.Forms.Label lblCacheProcess;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCache;
        private System.Windows.Forms.Label lblSortBy;
        private System.Windows.Forms.ComboBox cbSortBy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Label lblElasticSearchInformation;
        private System.Windows.Forms.Button btnCheckCacheInformation;
        private System.Windows.Forms.Button btnDeleteSelectedIndex;
    }
}

