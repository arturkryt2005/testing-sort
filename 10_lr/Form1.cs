using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10_lr
{
    public partial class Form1 : Form
    {
        public Context context;
        public int count = 0;
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            IOFile.form1 = this;
            Bubble.form1 = this;
            buble.form1 = this;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void AddItemsListBox(int first = -1, int second = -1)
        {
            listBox1.Items.Add("");
            foreach (var item in Context.array)
            {
                if (item == first || item == second)
                {
                    listBox1.Items[count] += '[' + Convert.ToString(item) + ']' + " ";
                }
                else
                {
                    listBox1.Items[count] += Convert.ToString(item) + " ";
                }
            }
            count++;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Context.array == null)
            {
                Generator generator = new Generator();
                Generator.form1 = this;
                generator.Show();

                button2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ошибка! Массив уже сгенерирован. Необходимо очистить старый набор и повторите попытку!");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (Context.array != null)
            {
                if (radioButton1.Checked == true)
                {
                    this.context = new Context(new Bubble());
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
                    IOFile.SaveData();
                    button3.Enabled = false;
                }
                if (radioButton2.Checked == true)
                {
                    this.context = new Context(new buble());
                    context.ExecuteAlgorithm();
                    this.AddItemsListBox();
                    IOFile.SaveData();
                    button3.Enabled = false;
                }
                IOFile.content = "";
            }

            else
            {
                MessageBox.Show("Массив пуст, сортировка невозможна");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button3.Enabled = true;
            listBox1.Items.Clear();
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            ComparativeAnalysis.NumberOfPermutations = 0;
            ComparativeAnalysis.Comparison = 0;
            Context.array = null;
            this.count = 0;
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {
            ComparativeAnalysis comparativeAnalysis = new ComparativeAnalysis();
            comparativeAnalysis.Show();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
        }

        private void открытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            IOFile.LoadData();
        }
    }
}
    