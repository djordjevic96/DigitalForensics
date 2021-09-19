
namespace DigitalForensics
{
    partial class Filter_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filter_Form));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbxFileType = new System.Windows.Forms.GroupBox();
            this.clbFileTypes = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblIndexInformation = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxFilterOptions = new System.Windows.Forms.ComboBox();
            this.cbxFilterPeriod = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.gbxFiles = new System.Windows.Forms.GroupBox();
            this.btnShowStatistics = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNumberOfFiles = new System.Windows.Forms.Label();
            this.lblNumOfFiles = new System.Windows.Forms.Label();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSearchByNameNumber = new System.Windows.Forms.Label();
            this.dgvSearchByName = new System.Windows.Forms.DataGridView();
            this.btnSearchByName = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSearchByName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.gbxFileType.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchByName)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbxFileType);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 845);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter options:";
            // 
            // gbxFileType
            // 
            this.gbxFileType.Controls.Add(this.clbFileTypes);
            this.gbxFileType.Location = new System.Drawing.Point(17, 548);
            this.gbxFileType.Name = "gbxFileType";
            this.gbxFileType.Size = new System.Drawing.Size(184, 213);
            this.gbxFileType.TabIndex = 21;
            this.gbxFileType.TabStop = false;
            this.gbxFileType.Text = "File Type:";
            // 
            // clbFileTypes
            // 
            this.clbFileTypes.FormattingEnabled = true;
            this.clbFileTypes.Items.AddRange(new object[] {
            "All"});
            this.clbFileTypes.Location = new System.Drawing.Point(24, 19);
            this.clbFileTypes.Name = "clbFileTypes";
            this.clbFileTypes.Size = new System.Drawing.Size(120, 169);
            this.clbFileTypes.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblIndexInformation);
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(17, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(184, 179);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Indexes list";
            // 
            // lblIndexInformation
            // 
            this.lblIndexInformation.AutoSize = true;
            this.lblIndexInformation.Location = new System.Drawing.Point(8, 154);
            this.lblIndexInformation.Name = "lblIndexInformation";
            this.lblIndexInformation.Size = new System.Drawing.Size(83, 13);
            this.lblIndexInformation.TabIndex = 25;
            this.lblIndexInformation.Text = "Selected index :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(158, 115);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cbxFilterOptions);
            this.groupBox3.Controls.Add(this.cbxFilterPeriod);
            this.groupBox3.Location = new System.Drawing.Point(17, 204);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(184, 144);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter options";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Option:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Period:";
            // 
            // cbxFilterOptions
            // 
            this.cbxFilterOptions.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbxFilterOptions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxFilterOptions.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbxFilterOptions.FormattingEnabled = true;
            this.cbxFilterOptions.Items.AddRange(new object[] {
            "Show All",
            "Time Created",
            "Last Modify Time",
            "Last Access Time"});
            this.cbxFilterOptions.Location = new System.Drawing.Point(23, 44);
            this.cbxFilterOptions.Name = "cbxFilterOptions";
            this.cbxFilterOptions.Size = new System.Drawing.Size(121, 21);
            this.cbxFilterOptions.TabIndex = 2;
            this.cbxFilterOptions.SelectedIndexChanged += new System.EventHandler(this.cbxFilterOptions_SelectedIndexChanged);
            // 
            // cbxFilterPeriod
            // 
            this.cbxFilterPeriod.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbxFilterPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxFilterPeriod.FormattingEnabled = true;
            this.cbxFilterPeriod.Items.AddRange(new object[] {
            "For Day",
            "For Period",
            "For 30 Days"});
            this.cbxFilterPeriod.Location = new System.Drawing.Point(23, 108);
            this.cbxFilterPeriod.Name = "cbxFilterPeriod";
            this.cbxFilterPeriod.Size = new System.Drawing.Size(121, 21);
            this.cbxFilterPeriod.TabIndex = 3;
            this.cbxFilterPeriod.SelectedIndexChanged += new System.EventHandler(this.cbxFilterPeriod_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Location = new System.Drawing.Point(28, 784);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(158, 23);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "🔍 Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Controls.Add(this.dtpPeriodTo);
            this.groupBox2.Controls.Add(this.dtpPeriodFrom);
            this.groupBox2.Location = new System.Drawing.Point(17, 354);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 178);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time Period:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(20, 106);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 7;
            this.lblTo.Text = "To:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(21, 44);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 6;
            this.lblFrom.Text = "From:";
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodTo.Location = new System.Drawing.Point(23, 122);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.Size = new System.Drawing.Size(120, 20);
            this.dtpPeriodTo.TabIndex = 5;
            this.dtpPeriodTo.Value = new System.DateTime(2020, 1, 17, 14, 23, 2, 0);
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(23, 60);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.Size = new System.Drawing.Size(120, 20);
            this.dtpPeriodFrom.TabIndex = 4;
            this.dtpPeriodFrom.Value = new System.DateTime(2020, 1, 17, 14, 23, 2, 0);
            // 
            // gbxFiles
            // 
            this.gbxFiles.Controls.Add(this.btnShowStatistics);
            this.gbxFiles.Controls.Add(this.label3);
            this.gbxFiles.Controls.Add(this.tbxSearch);
            this.gbxFiles.Controls.Add(this.label4);
            this.gbxFiles.Controls.Add(this.lblNumberOfFiles);
            this.gbxFiles.Controls.Add(this.lblNumOfFiles);
            this.gbxFiles.Controls.Add(this.dgvFiles);
            this.gbxFiles.Location = new System.Drawing.Point(261, 12);
            this.gbxFiles.Name = "gbxFiles";
            this.gbxFiles.Size = new System.Drawing.Size(620, 845);
            this.gbxFiles.TabIndex = 18;
            this.gbxFiles.TabStop = false;
            this.gbxFiles.Text = "Files:";
            // 
            // btnShowStatistics
            // 
            this.btnShowStatistics.Location = new System.Drawing.Point(581, 31);
            this.btnShowStatistics.Name = "btnShowStatistics";
            this.btnShowStatistics.Size = new System.Drawing.Size(27, 23);
            this.btnShowStatistics.TabIndex = 24;
            this.btnShowStatistics.Text = "🖻 ";
            this.btnShowStatistics.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Search:";
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(67, 28);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(126, 20);
            this.tbxSearch.TabIndex = 20;
            this.tbxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSearch_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 812);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "*Double Click on any row to open file statistics";
            // 
            // lblNumberOfFiles
            // 
            this.lblNumberOfFiles.AutoSize = true;
            this.lblNumberOfFiles.Location = new System.Drawing.Point(108, 812);
            this.lblNumberOfFiles.Name = "lblNumberOfFiles";
            this.lblNumberOfFiles.Size = new System.Drawing.Size(42, 13);
            this.lblNumberOfFiles.TabIndex = 18;
            this.lblNumberOfFiles.Text = "number";
            this.lblNumberOfFiles.Visible = false;
            // 
            // lblNumOfFiles
            // 
            this.lblNumOfFiles.AutoSize = true;
            this.lblNumOfFiles.Location = new System.Drawing.Point(17, 812);
            this.lblNumOfFiles.Name = "lblNumOfFiles";
            this.lblNumOfFiles.Size = new System.Drawing.Size(85, 13);
            this.lblNumOfFiles.TabIndex = 17;
            this.lblNumOfFiles.Text = "Number Of Files:";
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AllowUserToOrderColumns = true;
            this.dgvFiles.AllowUserToResizeRows = false;
            this.dgvFiles.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Location = new System.Drawing.Point(17, 67);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.RowHeadersWidth = 51;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(591, 740);
            this.dgvFiles.TabIndex = 16;
            this.dgvFiles.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellContentDoubleClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.lblSearchByNameNumber);
            this.groupBox5.Controls.Add(this.dgvSearchByName);
            this.groupBox5.Controls.Add(this.btnSearchByName);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.tbSearchByName);
            this.groupBox5.Location = new System.Drawing.Point(893, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(511, 845);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "File search by Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 812);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "*Double Click on any row to open file statistics";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 812);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Number Of Files:";
            // 
            // lblSearchByNameNumber
            // 
            this.lblSearchByNameNumber.AutoSize = true;
            this.lblSearchByNameNumber.Location = new System.Drawing.Point(107, 812);
            this.lblSearchByNameNumber.Name = "lblSearchByNameNumber";
            this.lblSearchByNameNumber.Size = new System.Drawing.Size(42, 13);
            this.lblSearchByNameNumber.TabIndex = 26;
            this.lblSearchByNameNumber.Text = "number";
            this.lblSearchByNameNumber.Visible = false;
            // 
            // dgvSearchByName
            // 
            this.dgvSearchByName.AllowUserToAddRows = false;
            this.dgvSearchByName.AllowUserToDeleteRows = false;
            this.dgvSearchByName.AllowUserToOrderColumns = true;
            this.dgvSearchByName.AllowUserToResizeRows = false;
            this.dgvSearchByName.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSearchByName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchByName.Location = new System.Drawing.Point(19, 69);
            this.dgvSearchByName.Name = "dgvSearchByName";
            this.dgvSearchByName.ReadOnly = true;
            this.dgvSearchByName.RowHeadersVisible = false;
            this.dgvSearchByName.RowHeadersWidth = 51;
            this.dgvSearchByName.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearchByName.Size = new System.Drawing.Size(470, 738);
            this.dgvSearchByName.TabIndex = 25;
            this.dgvSearchByName.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchByName_CellContentDoubleClick);
            // 
            // btnSearchByName
            // 
            this.btnSearchByName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchByName.Location = new System.Drawing.Point(386, 25);
            this.btnSearchByName.Name = "btnSearchByName";
            this.btnSearchByName.Size = new System.Drawing.Size(103, 23);
            this.btnSearchByName.TabIndex = 24;
            this.btnSearchByName.Text = "Search";
            this.btnSearchByName.UseVisualStyleBackColor = true;
            this.btnSearchByName.Click += new System.EventHandler(this.btnSearchByName_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Search:";
            // 
            // tbSearchByName
            // 
            this.tbSearchByName.Location = new System.Drawing.Point(66, 28);
            this.tbSearchByName.Name = "tbSearchByName";
            this.tbSearchByName.Size = new System.Drawing.Size(187, 20);
            this.tbSearchByName.TabIndex = 22;
            // 
            // Filter_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 868);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.gbxFiles);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Filter_Form";
            this.Text = "Filter Form";
            this.Load += new System.EventHandler(this.Filter_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbxFileType.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxFiles.ResumeLayout(false);
            this.gbxFiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchByName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxFilterOptions;
        private System.Windows.Forms.ComboBox cbxFilterPeriod;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.GroupBox gbxFiles;
        private System.Windows.Forms.Button btnShowStatistics;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNumberOfFiles;
        private System.Windows.Forms.Label lblNumOfFiles;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox gbxFileType;
        private System.Windows.Forms.CheckedListBox clbFileTypes;
        private System.Windows.Forms.Label lblIndexInformation;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSearchByNameNumber;
        private System.Windows.Forms.DataGridView dgvSearchByName;
        private System.Windows.Forms.Button btnSearchByName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSearchByName;
    }
}