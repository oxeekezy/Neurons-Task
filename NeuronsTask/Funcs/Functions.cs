using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronsTask.Funcs
{
    internal class Functions
    {
        public double Linear(double x)
        {
            return x;
        }
        public double Sigmoid(double x) 
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public double OneDivideSqrt(double x) 
        {
            return 1 / Math.Sqrt(x);
        }

        public double Tanh(double x) 
        {
            return Math.Tanh(x);
        }
        
    }
}
