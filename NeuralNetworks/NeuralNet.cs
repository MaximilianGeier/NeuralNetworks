using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworks
{
    class NeuralNet
    {
        public Neuron[] InputLayer { get; set; }
        public Neuron[][] HiddenLayers { get; set; }
        public Neuron[] OutputLayer { get; set; }

        public NeuralNet(int inputLayerSize, int hiddenLayerCount, int hiddenLayerSize, int outputLayerSize)
        {
            OutputLayer = GenerateArray(outputLayerSize, 0); //create output layer
            InputLayer = GenerateArray(inputLayerSize, hiddenLayerSize); //create input layer. Thanks Cap
            HiddenLayers = new Neuron[hiddenLayerCount][]; //create hidden layers
            for (int i = 0; i < hiddenLayerCount - 1; i++)
                HiddenLayers[i] = GenerateArray(hiddenLayerSize, hiddenLayerSize);
            HiddenLayers[hiddenLayerCount - 1] = GenerateArray(hiddenLayerSize, outputLayerSize);

            foreach (Neuron neuron in InputLayer)
            {
                for (int i = 0; i < hiddenLayerSize; i++)
                {
                    neuron.Synapses[i].Child = HiddenLayers[0][i];
                    neuron.Synapses[i].Parent = neuron; //???
                }
            }
            for(int i = 0; i < hiddenLayerCount - 1; i++)
            {
                for(int j = 0; j < hiddenLayerSize; j++)
                {
                    for(int k = 0; k < hiddenLayerSize; k++)
                    {
                        HiddenLayers[i][j].Synapses[k].Child = HiddenLayers[i + 1][k];
                    }
                }
            }
            for (int i = 0; i < hiddenLayerSize; i++)
            {
                for (int j = 0; j < outputLayerSize; j++)
                {
                    HiddenLayers[hiddenLayerCount - 1][i].Synapses[j].Child = OutputLayer[j];
                }
            }
        }

        public NeuralNet(int inputLayerSize, int outputLayerSize)
        {
            InputLayer = GenerateArray(inputLayerSize, outputLayerSize); //create input layer. Thanks Cap
            OutputLayer = GenerateArray(outputLayerSize, 0); //create output layer

            foreach (Neuron neuron in InputLayer)
            {
                for (int i = 0; i < outputLayerSize; i++)
                {
                    neuron.Synapses[i].Child = OutputLayer[i];
                    neuron.Synapses[i].Parent = neuron; //???
                }
            }
        }

        private Neuron[] GenerateArray(int size, int nextLayerSize)
        {
            Neuron[] output = new Neuron[size];
            for(int i = 0; i < output.Length; i++)
            {
                output[i] = new Neuron();
                output[i].Synapses = new List<Synapse>();
                for(int index = 0; index < nextLayerSize; index++)
                    output[i].Synapses.Add(new Synapse());

                output[i].ActivateWeights();
            }
            return output;
        }

        public double[] GetResult(double[] inputValues)
        {
            if (inputValues.Length != InputLayer.Length)
                throw new ArgumentException("Переданно неверное количество данных");
            for(int i = 0; i < InputLayer.Length;i++)
                InputLayer[i].Value = inputValues[i];

            for (int i = 0; i < InputLayer.Length; i++)
                InputLayer[i].TryAct();
            for (int i = 0; i < HiddenLayers.Length; i++)
            {
                for (int j = 0; j < HiddenLayers[i].Length; j++)
                {
                    HiddenLayers[i][j].TryAct();
                }
            }
            double[] result = new double[OutputLayer.Length];
            for (int i = 0; i < OutputLayer.Length; i++)
                result[i] = OutputLayer[i].Value;
            return result;
        }
    }
}
