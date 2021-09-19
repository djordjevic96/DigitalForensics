using DigitalForensics.ElasticSearch.ElasticSearchFunctions;
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
using DigitalForensics.ElasticSearch.ElasticSearchFunctions;

namespace DigitalForensics
{
    public partial class Filter_Form : Form
    {
        private string Partition;
        private string SelectedIndex;
        private List<DocumentAttributes> ret;
        private List<string> indexNames;
        

        public enum FilterOptions
        {
            ShowAll,
            TimeCreated,
            LastModifyTime,
            LastAccessTime
        }

        public enum FilterPeriod
        {
            ForDay,
            ForPeriod,
            For30Days
        }

        public Filter_Form()
        {
            InitializeComponent();
            Partition = "";
            SelectedIndex = "c1692021";
            ret = new List<DocumentAttributes>();
        }

        public Filter_Form(string partitionName)
        {
            InitializeComponent();
            Partition = partitionName;
            SelectedIndex = "c1692021";
            PopulateFileTypeCB();
            ret = new List<DocumentAttributes>();
            indexNames = new List<string>();
        }

        public void ShowIndexes()
        {

            DataTable retDataTable = ElasticSearchHelperClass.getAllIndexesForPartition(Partition);
            if (retDataTable != null)
            {
                dataGridView1.DataSource = retDataTable;
                for(int i=0;i<retDataTable.Rows.Count;i++)
                {
                    indexNames.Add(retDataTable.Rows[i]["Name"].ToString());
                }
            }
        }

        private void Filter_Form_Load(object sender, EventArgs e)
        {
            ShowIndexes();
            SetUpDateTimePickers();
            
        }


        public void SetUpDateTimePickers()
        {
            dtpPeriodFrom.MinDate = DateTime.Now.AddYears(-10);
            dtpPeriodFrom.Value = DateTime.Now;
            dtpPeriodFrom.MaxDate = DateTime.Now;
            dtpPeriodTo.MinDate = DateTime.Now.AddYears(-10);
            dtpPeriodTo.Value = DateTime.Now;
            dtpPeriodTo.MaxDate = DateTime.Now;
        }
        public void PopulateFileTypeCB()
        {
            //Dodati da se vadi rezultat iz datagridview za index name
            List<string> ret = ElasticSearchQueries.getAllDistinctExtensions(SelectedIndex);

            if(ret != null)
            {
                clbFileTypes.Items.AddRange(ret.ToArray());
            }    
            

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedCells.Count>0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                SelectedIndex = Convert.ToString(selectedRow.Cells["Name"].Value);
            }
            lblIndexInformation.Text = "Selected index : " + SelectedIndex;
        }

        private void cbxFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComboboxesForFilterOptions();
        }

        public void SetComboboxesForFilterOptions()
        {
            switch (cbxFilterPeriod.SelectedIndex)
            {
                case -1:
                    dtpPeriodTo.Enabled = true;
                    dtpPeriodFrom.Enabled = true;
                    break;

                case 0: // For day
                    dtpPeriodTo.Enabled = false;
                    dtpPeriodFrom.Enabled = true;
                    break;

                case 1: // For period
                    dtpPeriodTo.Enabled = true;
                    dtpPeriodFrom.Enabled = true;
                    break;

                case 2: // For 30 days
                    dtpPeriodTo.Enabled = false;
                    dtpPeriodTo.Value = dtpPeriodTo.MaxDate;
                    dtpPeriodFrom.Enabled = false;
                    dtpPeriodFrom.Value = dtpPeriodTo.MaxDate.AddDays(-30);
                    break;

                default:
                    break;
            }
        }

        private void cbxFilterPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComboboxesForFilterOptions();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        public void PopulateDataGridView()
        {
            if (cbxFilterOptions.SelectedIndex == -1)
                return;


            FilterOptions selectedOption = (FilterOptions)cbxFilterOptions.SelectedIndex;
            FilterPeriod selectedPeriod = (FilterPeriod)cbxFilterPeriod.SelectedIndex;

            DateTime selectedDateFrom = dtpPeriodFrom.Value.Date;
            DateTime selectedDateTo = dtpPeriodTo.Value.Date;

            List<string> selectedTypes = clbFileTypes.CheckedItems.Cast<string>().ToList();

            switch (selectedOption)
            {
                case FilterOptions.ShowAll:
                    ShowAllFiles(selectedTypes);
                    break;

                case FilterOptions.TimeCreated:
                    ShowFilesByPeriodOfTime("CreationTime", selectedPeriod, selectedDateFrom, selectedDateTo, selectedTypes);
                    break;

                case FilterOptions.LastModifyTime:
                    ShowFilesByPeriodOfTime("LastModificationTime", selectedPeriod, selectedDateFrom, selectedDateTo, selectedTypes);
                    break;

                case FilterOptions.LastAccessTime:
                    ShowFilesByPeriodOfTime("LastAccessTime", selectedPeriod, selectedDateFrom, selectedDateTo, selectedTypes);
                    break;
                default:
                    break;
            }
        }

        public void SetUpDataGridViewColumnsSettings()
        {
            foreach (var column in dgvFiles.Columns.Cast<DataGridViewColumn>().ToList())
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        public void SetUpDataGridViewColumnsNameSettings()
        {
            foreach (var column in dgvSearchByName.Columns.Cast<DataGridViewColumn>().ToList())
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }


        public void ShowAllFiles(List<string> selectedTypes)
        {
            try
            {
                
                    List<DocumentAttributes> retrievedData = ElasticSearchQueries.getAllDocuments(SelectedIndex);
                ret = retrievedData;
                    dgvFiles.DataSource = retrievedData;
                
                
                    SetUpDataGridViewColumnsSettings();
                    lblNumberOfFiles.Visible = true;
                    lblNumberOfFiles.Text = dgvFiles.Rows.Count.ToString();
                                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ShowFilesByPeriodOfTime(string columnName, FilterPeriod selectedPeriod, DateTime selectedDateFrom, DateTime selectedDateTo, List<string> selectedTypes)
        {
            try
            {
                switch (selectedPeriod)
                {
                    case FilterPeriod.ForDay:
                        List<DocumentAttributes> retrievedData = ElasticSearchQueries.getFilesByPeriodOfTime(SelectedIndex, columnName, selectedTypes, selectedDateFrom);
                        dgvFiles.DataSource = retrievedData; ret = retrievedData;
                    
                        break;
                    default:
                        List<DocumentAttributes> retrievedData1 = ElasticSearchQueries.getFilesByPeriodOfTime(SelectedIndex, columnName, selectedTypes, selectedDateFrom, selectedDateTo);
                        dgvFiles.DataSource = retrievedData1; ret = retrievedData1;
                        break;
                }

                
                SetUpDataGridViewColumnsSettings();
                lblNumberOfFiles.Visible = true;
                lblNumberOfFiles.Text = dgvFiles.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tbxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ret == null || ret.Count == 0)
                return;

            dgvFiles.DataSource = ret.Where(x => x.Name.Contains(tbxSearch.Text)).ToList();
            dgvFiles.Update();
            dgvFiles.Refresh();
            lblNumberOfFiles.Text = dgvFiles.Rows.Count.ToString();
        }

        private void btnSearchByName_Click(object sender, EventArgs e)
        {
            if(DigitalForensics.ElasticSearch.ConnectionToES.EsClient()!=null)
            {
                string searchName = tbSearchByName.Text;
                if(searchName.Contains(" "))
                {
                    string[] listOfNames = searchName.Split(' ');
                    List<DocumentAttributes> retLista = ElasticSearchQueries.getDocumentsByNameWithSpace(SelectedIndex, listOfNames.ToList());
                    dgvSearchByName.DataSource = retLista;

                    SetUpDataGridViewColumnsNameSettings();
                    lblSearchByNameNumber.Visible = true;
                    lblSearchByNameNumber.Text = dgvSearchByName.Rows.Count.ToString();
                }
                else
                {
                    List<DocumentAttributes> retLista = ElasticSearchQueries.getDocumentsByName(SelectedIndex, tbSearchByName.Text);
                    dgvSearchByName.DataSource = retLista;

                    SetUpDataGridViewColumnsNameSettings();
                    lblSearchByNameNumber.Visible = true;
                    lblSearchByNameNumber.Text = dgvSearchByName.Rows.Count.ToString();
                }
                
            }
        }

        private void dgvFiles_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            Form frm = new FolderFileGraphicForm(SelectedIndex, Partition, (DocumentAttributes)dgvFiles.SelectedRows[0].DataBoundItem, indexNames);
            frm.Show();
        }

        private void dgvSearchByName_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form frm = new FolderFileGraphicForm(SelectedIndex, Partition, (DocumentAttributes)dgvSearchByName.SelectedRows[0].DataBoundItem, indexNames);
            frm.Show();
        }
    }
}
