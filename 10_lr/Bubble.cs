using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_lr
{
    public class Bubble : IStrategy
    {
        public int iterationCount = 0;
        public static Form1 form1;

        public int[] Algorithm(int[] mass, bool flag = true)
        {
            if (flag)
            {
                IOFile.FillContent();
                System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                myStopwatch.Start();

                for (int i = 0; i < mass.Length - 1; i++)
                {
                    for (int j = i + 1; j < mass.Length; j++)
                    {
                        this.iterationCount++;
                        IOFile.content += this.iterationCount.ToString() + " итерация: " + '\n';
                        IOFile.InputInfoAboutComparison(mass[i], mass[j]);
                        ComparativeAnalysis.Comparison++;

                        if (mass[i] > mass[j])
                        {
                            IOFile.InputInfoAboutTransposition(mass[i], mass[j]);
                            int temp = mass[i];
                            mass[i] = mass[j];
                            mass[j] = temp;
                            ComparativeAnalysis.NumberOfPermutations++;
                        }

                        IOFile.FillContent();
                        form1.AddItemsListBox(mass[i], mass[j]);
                    }
                }

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

                return mass;
            }
            else
            {
                System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                myStopwatch.Start();
                for (int i = 0; i < mass.Length - 1; i++)
                {
                    for (int j = i + 1; j < mass.Length; j++)
                    {
                        ComparativeAnalysis.Comparison++;
                        if (mass[i] > mass[j])
                        {
                            int temp = mass[i];
                            mass[i] = mass[j];
                            mass[j] = temp;
                            ComparativeAnalysis.NumberOfPermutations++;
                        }
                    }
                }
                myStopwatch.Stop();
                var resultTime = myStopwatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    resultTime.Hours,
                    resultTime.Minutes,
                    resultTime.Seconds,
                    resultTime.Milliseconds);
                ComparativeAnalysis.timeSort = resultTime.Seconds * 1000 + resultTime.Milliseconds;
                ComparativeAnalysis.elapsedTime = elapsedTime;
                return mass;
            }
        }
    }

}
