using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronsTask.Neurons
{
    internal class NeuronsNetwork
    {
        public double[] oldValues;
        private int _count;
        private double[] inputs = new double[] {0.7,0.3,1 };

        public NeuronsNetwork(int count) 
        {
            _count = count;
            List<Neuron> neurons = new List<Neuron>();

            for (int i = 0; i < count; i++)
            {
                neurons.Add(new Neuron(inputs));
            }

            oldValues = new double[neurons.Count];
            oldValues = neurons.Select(n => n.Calculation()).ToArray();
        }

        public double[] UpdateNeuronsNetwork(double[] input) 
        {
            List<Neuron> neurons = new List<Neuron>();
            for (int i = 0; i < _count; i++)
                neurons.Add(new Neuron(input));


            return neurons.Select(n => n.Calculation()).ToArray();
        }
    }
}
