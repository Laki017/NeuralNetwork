using System.Collections.Generic;

namespace NeuralNetworks
{
    public class Topology
    {
        public List<int> HiddenLayers { get; }
        public int InputCount { get; }
        public int OutputCount { get; }
        public double LearningRate { get; set; }
        

        public Topology(int inputCount, int outputCount, double learningRate, params int[] layers)
        {
            InputCount = inputCount;
            OutputCount = outputCount;
            LearningRate = learningRate;
            HiddenLayers = new List<int>();

            HiddenLayers.AddRange(layers);
        }

        
    }
    
}