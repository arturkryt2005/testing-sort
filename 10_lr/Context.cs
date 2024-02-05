using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_lr
{
    public class Context
    {
        public IStrategy ContextStrategy;
        public static int[] array;
        public Context(IStrategy Strategy)
        {
            this.ContextStrategy = Strategy;
        }
        public Context() { }
        public void ExecuteAlgorithm(bool flag = true)
        {
            ContextStrategy.Algorithm(array, flag);
        }
    }
}
