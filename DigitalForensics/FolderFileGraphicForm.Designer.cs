
namespace DigitalForensics
{
    partial class FolderFileGraphicForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderFileGraphicForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbGraphicOptions = new System.Windows.Forms.ComboBox();
            this.pnlFolderDetails = new System.Windows.Forms.Panel();
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
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            this.pnlFolderDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbGraphicOptions);
            this.groupBox1.Location = new System.Drawing.Point(133, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 61);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display Options";
            // 
            // cbGraphicOptions
            // 
            this.cbGraphicOptions.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.cbGraphicOptions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbGraphicOptions.ForeColor = System.Drawing.SystemColors.Window;
            this.cbGraphicOptions.FormattingEnabled = true;
            this.cbGraphicOptions.Items.AddRange(new object[] {
            "Size",
            "Number Of Files",
            "Time Access",
            "Time Modify"});
            this.cbGraphicOptions.Location = new System.Drawing.Point(21, 19);
            this.cbGraphicOptions.Name = "cbGraphicOptions";
            this.cbGraphicOptions.Size = new System.Drawing.Size(132, 21);
            this.cbGraphicOptions.TabIndex = 19;
            this.cbGraphicOptions.SelectedIndexChanged += new System.EventHandler(this.cbGraphicOptions_SelectedIndexChanged);
            // 
            // pnlFolderDetails
            // 
            this.pnlFolderDetails.BackColor = System.Drawing.SystemColors.WindowFrame;
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
            this.pnlFolderDetails.Location = new System.Drawing.Point(12, 12);
            this.pnlFolderDetails.Name = "pnlFolderDetails";
            this.pnlFolderDetails.Size = new System.Drawing.Size(451, 118);
            this.pnlFolderDetails.TabIndex = 19;
            // 
            // lblFolderFileType
            // 
            this.lblFolderFileType.AutoSize = true;
            this.lblFolderFileType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderFileType.ForeColor = System.Drawing.SystemColors.ControlLightLight;
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
            this.lblTypeLabel.ForeColor = System.Drawing.SystemColors.Control;
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
            this.lblFolderFileLastModify.ForeColor = System.Drawing.SystemColors.ControlLightLight;
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
            this.lblLastModifyLabel.ForeColor = System.Drawing.SystemColors.Control;
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
            this.lblFileFolderLastAccess.ForeColor = System.Drawing.SystemColors.ControlLightLight;
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
            this.lblLastAccessLabel.ForeColor = System.Drawing.SystemColors.Control;
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
            this.lblCreatedLabel.ForeColor = System.Drawing.SystemColors.Control;
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
            this.lblFolderFileSize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
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
            this.lblSizeLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
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
            this.lblFolderFileName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
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
            this.lblFolderFileLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.lblFolderFileLabel.Location = new System.Drawing.Point(13, 11);
            this.lblFolderFileLabel.Name = "lblFolderFileLabel";
            this.lblFolderFileLabel.Size = new System.Drawing.Size(99, 20);
            this.lblFolderFileLabel.TabIndex = 0;
            this.lblFolderFileLabel.Text = "Folder/File:";
            // 
            // chart
            // 
            this.chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chart.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(12, 203);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(451, 356);
            this.chart.TabIndex = 20;
            this.chart.Text = "chart";
            // 
            // FolderFileGraphicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 585);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.pnlFolderDetails);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FolderFileGraphicForm";
            this.Text = "Folder/File Graphic Form";
            this.groupBox1.ResumeLayout(false);
            this.pnlFolderDetails.ResumeLayout(false);
            this.pnlFolderDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbGraphicOptions;
        private System.Windows.Forms.Panel pnlFolderDetails;
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}