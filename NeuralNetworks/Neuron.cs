using System;
using System.Collections.Generic;

namespace NeuralNetworks
{
    public class Neuron
    {
        public List<double> Weights { get; }
        public List<double> Inputs { get; }
        public NeuronType NeuronType { get; }
        public double Output { get; private set; }
        public double Delta { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputCount"></param>
        /// <param name="type"></param>
        public Neuron(int inputCount, NeuronType type = NeuronType.Normal)
        {
            NeuronType = type;
            Weights = new List<double>();
            Inputs = new List<double>();


            IninWeightsRandomValue(inputCount);
        }

        private void IninWeightsRandomValue(int inputCount)
        {
            var rnd = new Random();

            for (var i = 0; i < inputCount; i++)
            {
                if (NeuronType == NeuronType.Input)
                {
                    Weights.Add(1);
                }
                else
                {
                    Weights.Add(rnd.NextDouble());
                }
                
                Inputs.Add(0);
            }
        }

        public double FeedForward(List<double> inputs)
        {
            var sum = 0.0;

            for (int i = 0; i < inputs.Count; i++)
            {
                Inputs[i] = inputs[i];
            }

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

        private double SigmoidDx(double x)
        {
            var sigmoid = Sigmoid(x);
            var result = sigmoid / (1 - sigmoid);
            return result;

        }

        public void Learn(double error, double lernindRate)
        {
            if (NeuronType == NeuronType.Input)
            {
                return;
            }

            Delta = error * SigmoidDx(Output);

            for (int i = 0; i < Weights.Count; i++)
            {
                var weight = Weights[i];
                var input = Inputs[i];
                var newWeignt = weight - input * Delta * lernindRate;
                Weights[i] = newWeignt;
            }
        }
        
        public override string ToString()
        {
            return Output.ToString();
        }
    }
}