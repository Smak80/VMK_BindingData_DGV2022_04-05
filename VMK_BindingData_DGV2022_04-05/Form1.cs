using System.ComponentModel;

namespace VMK_BindingData_DGV2022_04_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private BindingList<TableRowData> dataList = new();
        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Add("�������� 1_1", "�������� 1_2", "�������� 1_3", true);
            //dataGridView1.Rows.Add("�������� 2_1", "�������� 2_2", "�������� 2_3", false);
            
            dataGridView1.DataSource = dataList;
            dataList.Add(new TableRowData(1, "�������� 1_1", "�������� 1_2", true));
            dataList.Add(new TableRowData(2, "�������� 2_1", "�������� 2_2", false));
            dataList.Add(new TableRowData(3, "�������� 3_1", "�������� 3_2", true));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataList[1].IsChecked = !dataList[1].IsChecked;
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditForm();
        }

        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var d = dataGridView1.SelectedRows[0].Index;
                ShowEditForm(dataList[d]);
            }
        }

        private void ShowEditForm(TableRowData? d = null)
        {
            var f2 = new EditForm(d);
            //f2.Show(this);
            //f2.UserData = d;
            if (f2.ShowDialog(this) == DialogResult.OK)
            {
                dataList.Add(f2.UserData);
            }
        }
    }

}