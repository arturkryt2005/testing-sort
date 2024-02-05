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
    public partial class ComparativeAnalysis : Form
    {
        private Random random = new Random();
        public static int Comparison = 0;
        public static int NumberOfPermutations = 0;
        public static string elapsedTime = "";
        public static int timeSort = 0;
        public static List<SortingResultsInformation> sortingResults = new List<SortingResultsInformation>();
        private Context context = new Context();
        public ComparativeAnalysis()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Volume", "Объем выборки");
            dataGridView1.Columns.Add("ViborSort", "Метод обмена");
            dataGridView1.Columns.Add("Sort", "Метод поразрядной сортировки");
            dataGridView1.Rows.Add("10");
            dataGridView1.Rows.Add("100");
            dataGridView1.Rows.Add("1000");
            dataGridView1.Rows.Add("10000");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].ReadOnly = true;
            }

        }
        private void FillArray(int[] vs)
        {
            for (int i = 0; i < vs.Length; i++)
            {
                vs[i] = random.Next(0, 100000);
            }
        }
        private void Sort(int n, int number)
        {
            this.context = new Context(new Bubble());
            Context.array = new int[n];
            FillArray(Context.array);
            context.ExecuteAlgorithm(false);
            dataGridView1.Rows[number].Cells[1].Value += "Сравн: " + Convert.ToString(Comparison) + " ";
            dataGridView1.Rows[number].Cells[1].Value += "Перест: " + Convert.ToString(NumberOfPermutations) + " ";
            dataGridView1.Rows[number].Cells[1].Value += "Время: " + Convert.ToString(elapsedTime);
            sortingResults.Add(new SortingResultsInformation(Comparison, NumberOfPermutations, elapsedTime, new Bubble(), timeSort, n));
            Comparison = 0;
            NumberOfPermutations = 0;
            timeSort = 0;
            elapsedTime = "";
            Context.array = null;

            this.context = new Context(new buble());
            Context.array = new int[n];
            FillArray(Context.array);
            context.ExecuteAlgorithm(false);
            dataGridView1.Rows[number].Cells[2].Value += "Сравн: " + Convert.ToString(Comparison) + " ";
            dataGridView1.Rows[number].Cells[2].Value += "Перест: " + Convert.ToString(NumberOfPermutations) + " ";
            dataGridView1.Rows[number].Cells[2].Value += "Время: " + Convert.ToString(elapsedTime);
            sortingResults.Add(new SortingResultsInformation(Comparison, NumberOfPermutations, elapsedTime, new buble(), timeSort, n));
            Comparison = 0;
            NumberOfPermutations = 0;
            timeSort = 0;
            elapsedTime = "";
            Context.array = null;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ComparativeAnalysis_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "";
                }
            }

            Sort(10, 0);
            Sort(100, 1);
            Sort(1000, 2);
            Sort(10000, 3);

            SortingResultsInformation MaxElement;
            SortingResultsInformation MinElement;
            MaxElement = sortingResults[0];
            for (int i = 0; i < sortingResults.Count; i++)
            {
                if (MaxElement.Comparison < sortingResults[i].Comparison)
                {
                    MaxElement = sortingResults[i];
                }
            }
            MinElement = sortingResults[0];
            for (int i = 0; i < sortingResults.Count; i++)
            {
                if (MinElement.Comparison > sortingResults[i].Comparison)
                {
                    MinElement = sortingResults[i];
                }
            }
            label1.Text = MaxElement.NameSortingMethod + " с количествомсраненений равным " + MaxElement.Comparison + " дает худшие\n показателитрудоемкости сортировки для массива с\n количеством элементов равным " + MaxElement.Volume + ".";
            label2.Text = MinElement.NameSortingMethod + " с количествомсраненений равным " + MinElement.Comparison + " дает\n лучшие показателитрудоемкости сортировки\n для массива с количеством элементов равным " + MinElement.Volume + ".";
            sortingResults.Clear();
        }
    }
}
