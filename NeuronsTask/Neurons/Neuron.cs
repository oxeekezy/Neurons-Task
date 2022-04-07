using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NeuronsTask.Funcs;

namespace NeuronsTask.Neurons
{
    public class Neuron
    {
        public List<double> Weights { get; }
        public List<double> Inputs { get; }
        public NeuronType NeuronType { get; }
        public double Output { get; private set; }
        public double Delta { get; private set; }
        public string Test;

        public Neuron(int inputCount, NeuronType type = NeuronType.Normal)
        {
            NeuronType = type;
            Weights = new List<double>();
            Inputs = new List<double>();

            InitRandomWeights(inputCount);

        }

        private void InitRandomWeights(int inputCount)
        {
            var rnd = new Random();
            for (int i = 0; i < inputCount; i++)
            {
                if (NeuronType == NeuronType.Input)
                    Weights.Add(1);
                else
                    Weights.Add(rnd.NextDouble());
                Inputs.Add(0);
            }
        }

        public void SetFakeWeights(params double[] weights) 
        {
            for (int i = 0; i < weights.Length; i++)
            {
                Weights[i] = weights[i];
            }
        }

        public double FeedForward(List<double> inputs) 
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                Inputs[i] = inputs[i];
            }
            var sum = 0.0;

            for (int i = 0; i < inputs.Count; i++) 
            {
                sum += inputs[i] * Weights[i];
            }


            //TODO: switch to linear!
            if(NeuronType!=NeuronType.Input)
                Output = Sigmoid(sum);
            else
                Output = sum;

            return Output;

        }

        private double Sigmoid(double x)
        {
            //return 1.0 / (1.0 + Math.Exp(-x));
            //return x;
            return Math.Sqrt(x);
        }

        private double SigmoidDx(double x)
        {
            //return Sigmoid(x) / (1 - Sigmoid(x));
            return 1/2*Math.Sqrt(x);
        }

        public void Learn(double error, double learningSpeed) 
        {
            if (NeuronType == NeuronType.Input) 
            {
                return;
            }

            //TODO: switch to linear!
            //Delta = error * SigmoidDx(Output);!
            Delta = error * SigmoidDx(Output);

            for (int i = 0; i < Weights.Count; i++)
                Weights[i] = Weights[i] - Inputs[i] * Delta * learningSpeed;

        }

        public override string ToString()
        {
            return Output.ToString();
        }
    }    
}
