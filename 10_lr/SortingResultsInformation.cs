using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_lr
{
    public class SortingResultsInformation
    {
        public int Comparison = 0;
        public int NumberOfPermutations = 0;
        public int TimeSort = 0;
        public int Volume = 0;
        public string Time = "";
        public IStrategy Strategy;
        public string NameSortingMethod;

        public SortingResultsInformation(int Comparison, int NumberOfPermutations, string Time, IStrategy Strategy, int TimeSort, int Volume)
        {
            this.Comparison = Comparison;
            this.NumberOfPermutations = NumberOfPermutations;
            this.Time = Time;
            this.Strategy = Strategy;
            if (Strategy.GetType() == (new Bubble()).GetType())
            {
                this.NameSortingMethod = "Метод обмена";
            }
            else
            {
                this.NameSortingMethod = "Метод поразрядной сортровки";
            }
            this.TimeSort = TimeSort;
            this.Volume = Volume;
        }
    }
}
