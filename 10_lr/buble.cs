using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_lr
{
    public class buble : IStrategy
    {
        public int iterationCount = 0;
        public static Form1 form1;
        public void SortAnalysis(int[] array, int a, int b)
        {
            int i = a;
            int j = b;

            int middle = array[(a + b) / 2];
            while (i <= j)
            {
                while (array[i] < middle)
                {
                    i++;
                }
                while (array[j] > middle)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temporaryVariable = array[i];
                    array[i] = array[j];
                    array[j] = temporaryVariable;
                    i++;
                    j--;
                }
                ComparativeAnalysis.NumberOfPermutations++;
            }
            ComparativeAnalysis.Comparison++;
            if (a < j)
            {
                SortAnalysis(array, a, j);
            }
            if (i < b)
            {
                SortAnalysis(array, i, b);
            }
        }
        public void SortAnalysisFlag(int[] array, int a, int b)
        {
            int i = a;
            int j = b;
            int middle = array[(a + b) / 2];
            while (i <= j)
            {
                while (array[i] < middle)
                {
                    i++;
                }
                while (array[j] > middle)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temporaryVariable = array[i];
                    array[i] = array[j];
                    array[j] = temporaryVariable;
                    i++;
                    j--;
                }
                IOFile.content += this.iterationCount.ToString() + " итерация: " + '\n';
                IOFile.InputInfoAboutComparison(array[i], array[j]);
                IOFile.InputInfoAboutTransposition(array[i], array[j]);
                IOFile.FillContent();
                ComparativeAnalysis.NumberOfPermutations++;
            }
            this.iterationCount++;
            ComparativeAnalysis.Comparison++;
            form1.AddItemsListBox(array[i]);
            if (a < j)
            {
                SortAnalysisFlag(array, a, j);
            }
            if (i < b)
            {
                SortAnalysisFlag(array, i, b);
            }
        }

        public int[] Algorithm(int[] mas, bool flag = true)
        {
            int range = 1000;
            ArrayList[] lists = new ArrayList[range];
            for (int i = 0; i < range; ++i)
                lists[i] = new ArrayList();
            for (int step = 0; step < 1000; ++step)
            {
                //распределение по спискам
                for (int i = 0; i < mas.Length; ++i)
                {
                    int temp = (mas[i] % (int)Math.Pow(range, step + 1)) / (int)Math.Pow(range, step);
                    lists[temp].Add(mas[i]);
                }
                //сборка
                int k = 0;
                for (int i = 0; i < range; ++i)
                {
                    for (int j = 0; j < lists[i].Count; ++j)
                    {
                        mas[k++] = (int)lists[i][j];
                    }
                }
                for (int i = 0; i < range; ++i)
                    lists[i].Clear();
            }

            if (flag)
            {
                IOFile.FillContent();
                System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                myStopwatch.Start();
                SortAnalysisFlag(mas, 0, mas.Length - 1);
                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    resultTime.Hours,
                    resultTime.Minutes,
                    resultTime.Seconds,
                    resultTime.Milliseconds);
                form1.label6.Text = Convert.ToString(ComparativeAnalysis.Comparison);
                form1.label7.Text = Convert.ToString(ComparativeAnalysis.NumberOfPermutations);
                form1.label8.Text = elapsedTime;
                return mas;
            }
            else
            {
                System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                myStopwatch.Start();
                SortAnalysis(mas, 0, mas.Length - 1);
                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    resultTime.Hours,
                    resultTime.Minutes,
                    resultTime.Seconds,
                    resultTime.Milliseconds);
                ComparativeAnalysis.timeSort = resultTime.Seconds * 1000 + resultTime.Milliseconds;
                ComparativeAnalysis.elapsedTime = elapsedTime;
                return mas;
            }
        }


    }
}
