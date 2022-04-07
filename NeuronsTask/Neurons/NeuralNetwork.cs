using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronsTask.Neurons
{
    public class NeuralNetwork
    {
        public List<Layer> Layers { get; }
        public Topology Topology { get; }

        public List<List<Neuron>> f = new List<List<Neuron>>();

        public NeuralNetwork(Topology topology) 
        {
            Topology = topology;
            Layers = new List<Layer>();


            CreateInputLayer();
            CreateHiddenLayers();
            CreateOutputLayer();

        }

        public Neuron FeedForward(params double[] inputSignals)
        {
            SendSignalsToInputNeurons(inputSignals);
            FeedForwardAllLayersAfterInput();

            f.Add(Layers.Last().Neurons);

            if (Topology.OutputCount == 1)
            {
                return Layers.Last().Neurons[0];
            }
            else
            {
                return Layers.Last().Neurons
                    .OrderByDescending(x => x.Output)
                    .First();
            }

        }

        private void FeedForwardAllLayersAfterInput()
        {
            for (int i = 1; i < Layers.Count; i++)
            {
                var layer = Layers[i];
                var prevLayerSignals = Layers[i - 1].GetSignals();

                foreach (var neuron in layer.Neurons)
                {
                    neuron.FeedForward(prevLayerSignals);
                }
            }
        }

        private void SendSignalsToInputNeurons(params double[] inputSignals) 
        {
            for (int i = 0; i < inputSignals.Length; i++)
            {
                var signal = new List<double>() { inputSignals[i] };
                var neuron = Layers[0].Neurons[i];

                neuron.FeedForward(signal);
            }
        }

        private void CreateOutputLayer()
        {
            var outputNeurons = new List<Neuron>();
            var lastLayer = Layers.Last();
            for (int i = 0; i < Topology.OutputCount; i++)
            {
                var neuron = new Neuron(lastLayer.Count, NeuronType.Output);
                outputNeurons.Add(neuron);
            }
            var outputLayer = new Layer(outputNeurons, NeuronType.Output);
            Layers.Add(outputLayer);
        }

        private void CreateHiddenLayers()
        {
            var hiddenNeurons = new List<Neuron>();
            var lastLayer = Layers.Last();
            for (int j = 0; j < Topology.HiddenLayers.Count; j++) 
            {
                for (int i = 0; i < Topology.HiddenLayers[j]; i++)
                {
                    var neuron = new Neuron(lastLayer.Count);
                    hiddenNeurons.Add(neuron);
                }
                var hiddenLayer = new Layer(hiddenNeurons);
                Layers.Add(hiddenLayer);
            }   
        }

        private void CreateInputLayer() 
        {
            var inputNeurons = new List<Neuron>();
            for (int i = 0; i < Topology.InputCount; i++)
            {
                var neuron = new Neuron(1, NeuronType.Input);
                inputNeurons.Add(neuron);
            }
            var inputLayer = new Layer(inputNeurons, NeuronType.Input);
            Layers.Add(inputLayer);
        }

        public double Learn(List<(double,double[])> dataset, int epoches) 
        {
            var error = 0.0;

            for (int i = 0; i < epoches; i++)
            {
                foreach (var data in dataset)
                {
                    error += BackPropagation(data.Item1, data.Item2);
                }
            }

            return error / epoches;
        }
        private double BackPropagation(double expected, params double[] inputs) 
        {
            var actual = FeedForward(inputs).Output;
            var diff = actual - expected;

            foreach (var neuron in Layers.Last().Neurons)
            {
                neuron.Learn(diff, Topology.LearningSpeed);
            }

            for (int j = Layers.Count - 2; j >= 0; j--)
            {
                var layer = Layers[j];
                var previousLayer = Layers[j + 1];

                for (int i = 0; i < layer.Count; i++)
                {
                    var neuron = layer.Neurons[i];

                    for (int k = 0; k < previousLayer.Count; k++)
                    {
                        var previousNeuron = previousLayer.Neurons[k];
                        var error = previousNeuron.Weights[i] * previousNeuron.Delta;
                        neuron.Learn(error, Topology.LearningSpeed);
                    }
                }
            }

            return Math.Abs(diff);
        }

    }
}
