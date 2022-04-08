using System.ComponentModel;
using System.Text;

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
            
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newData = new TableRowData();
            var f2 = new EditForm(newData);
            //f2.Show(this);
            if (f2.ShowDialog(this) == DialogResult.OK)
            {
                dataList.Add(newData);
            }
        }

        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f2 = new EditForm(dataList[dataGridView1.SelectedRows[0].Index]);
            if (f2.ShowDialog(this) == DialogResult.OK)
            {
                //dataList.Add(f2.UserData);
            }
        }
    }

}