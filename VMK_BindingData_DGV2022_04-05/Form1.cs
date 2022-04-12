using System.ComponentModel;
using System.Text;
using System.Text.Json;

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
            dataGridView1.DataSource = dataList;
            dataList.Add(new TableRowData(1, "�������� 1_1", "�������� 1_2", true));
            dataList.Add(new TableRowData(2, "�������� 2_1", "�������� 2_2", false));
            dataList.Add(new TableRowData(3, "�������� 3_1", "�������� 3_2", true));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                var filename = saveFileDialog1.FileName;
                using var file = new FileStream(filename, FileMode.Create);
                using var sw = new StreamWriter(file, Encoding.UTF8);
                var jso = new JsonSerializerOptions();
                jso.WriteIndented = false;
                foreach (var elem in dataList)
                {
                    sw.WriteLine(JsonSerializer.Serialize<TableRowData>(elem, jso));
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                using var sr = new StreamReader(filename, Encoding.UTF8);
                dataList.Clear();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine() ?? "";
                    var obj = JsonSerializer.Deserialize<TableRowData>(line);
                    if (obj is not null)
                    {
                        dataList.Add(obj);
                    }
                }
            }
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f2 = new EditForm();
            //f2.Show(this); //-- �������� ����� � ����������� ������
            if (f2.ShowDialog(this) == DialogResult.OK)
            {
                dataList.Add(f2.UserData);
            }
        }

        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f2 = new EditForm(dataList[dataGridView1.SelectedRows[0].Index]);
            f2.ShowDialog(this);
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("�� �������, ��� ������ ������� ������ �� ������?", "��������!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show("���� ����� �������? ������ ������ ����� ������������!", "��!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (MessageBox.Show("��, ����� � ������, ��?", "��������� ����!", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Hand) == DialogResult.Yes)
                    {
                        dataList.RemoveAt(dataGridView1.SelectedRows[0].Index);
                        MessageBox.Show("������! ;(", "��! :(", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            MessageBox.Show("�� � ���������! ���� �� ��� ���� ��� ����������!", "(...�����������...)",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                var filename = saveFileDialog1.FileName;
                using var fs = new FileStream(filename, FileMode.Create);
                JsonSerializer.Serialize(fs, dataList);
            }
        }
    }

}