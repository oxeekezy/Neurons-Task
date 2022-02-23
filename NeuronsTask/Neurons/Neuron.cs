using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuronsTask.Funcs;

namespace NeuronsTask.Neurons
{
    internal class Neuron
    {
        public double _bias;
        private double[] _weights;
        private double[] _input;

        public Neuron(double[] input)
        {
            _input = input;
            _weights = new double[input.Length];

            Random rand = new Random();

            for (int i = 0; i < _weights.Length; i++)
                _weights[i] = rand.NextDouble() + 1;
            _bias = rand.NextDouble()+1;
        }

        public double Calculation()
        {
            double sum = 0;

            for(int i=0; i<_input.Length; i++)
                sum += _input[i] * _weights[i];
            sum += _bias;

            return new Functions().Sigmoid(sum); 
        }

        public string GetWeights() 
        {
            string w = string.Empty;
            for (int i = 0; i < _weights.Length; i++) 
            {
                w+=_weights[i]+" | ";
            }
            return w;
        }

    }
}
