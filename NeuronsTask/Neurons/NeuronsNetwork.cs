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

        public NeuronsNetwork(int count) 
        {
            _count = count;
            List<Neuron> neurons = new List<Neuron>();

            neurons.Add(new Neuron(new double[] { 5, 8, 10 }));
            neurons.Add(new Neuron(new double[] { 23, 18, 9}));
            neurons.Add(new Neuron(new double[] { 100090, 23423423, 1231212 }));

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
