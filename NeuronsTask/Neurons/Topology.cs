using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronsTask.Neurons
{
    public class Topology
    {
        public int InputCount { get;}
        public int OutputCount { get;}
        public double LearningSpeed { get; }
        public List<int> HiddenLayers { get; }

        public Topology(int inputCount, int outputCount, double learningSpeed, params int[] layers) 
        {
            InputCount = inputCount;
            OutputCount = outputCount;
            HiddenLayers = new List<int>();
            HiddenLayers.AddRange(layers);
            LearningSpeed = learningSpeed;

        }
    }
}
