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
            InputLayer = GenerateArray(inputLayerSize);
            HiddenLayers = new Neuron[hiddenLayerCount][];
            for (int i = 0; i < hiddenLayerCount; i++)
                HiddenLayers[i] = GenerateArray(hiddenLayerSize);
            OutputLayer = GenerateArray(outputLayerSize);
        }

        private Neuron[] GenerateArray(int size)
        {
            Neuron[] output = new Neuron[size];
            for(int i = 0; i < output.Length; i++)
                output[i] = new Neuron();
            return output;
        }
    }
}
