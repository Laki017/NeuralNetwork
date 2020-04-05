using System;
using System.Collections.Generic;

namespace NeuralNetworks
{
    public class Neuron
    {
        public List<double> Weights { get; }
        public NeuronType NeuronType { get; }
        public double Output { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputCount"></param>
        /// <param name="type"></param>
        public Neuron(int inputCount, NeuronType type = NeuronType.Normal)
        {
            NeuronType = type;
            Weights = new List<double>();
            for (int i = 0; i < inputCount; i++)
            {
                Weights.Add(1);
            }
        }

        public double FeedForward(List<double> inputs)
        {
            var sum = 0.0;
            for (int i = 0; i < inputs.Count; i++)
            {
                sum += inputs[i] * Weights[i];
            }

            if (NeuronType != NeuronType.Input)
            {
                Output = Sigmoid(sum);
            }
            else
            {
                Output = sum;
            }

            return Output;
        }

        private double Sigmoid(double x)
        {
            var result = 1.0 / (1.0 + Math.Pow(Math.E, -x));
            return result;
        }

        // TODO: Удалить после реализации обучения
        public void SetWigths(params double[] weigths)
        {
            for (int i = 0; i < weigths.Length; i++)
            {
                Weights[i] = weigths[i];
            }
        }
        
        public override string ToString()
        {
            return Output.ToString();
        }
    }
}