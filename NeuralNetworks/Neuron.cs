using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworks
{
    class Neuron
    {
        public List<Synapse> Synapses = new List<Synapse>();
        public double Value { get; set; }
        public void TryAct(double Value) //добавить сюда функцию
        {
            Activate(Value);
        }
        void Activate(double value)
        {
            foreach(Synapse syn in Synapses)
            {
                syn.Child.Value += value * syn.Weight;
            }
        }
    }

    class Synapse
    {
        public double Weight { get; set; }
        public Neuron Parent { get; set; }
        public Neuron Child { get; set; }
    }
}

