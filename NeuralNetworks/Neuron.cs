using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworks
{
    class Neuron
    {
        public List<Synapse> Synapses = new List<Synapse>(); //synapses conects to children neurons
        public double Value { get; set; }

        public void ActivateWeights() //activate weights when creating neurons
        {
            var rnd = new Random();
            foreach (var s in Synapses)
            {
                s.Weight = (double)rnd.Next(20) / 100;
            }
        }

        public void TryAct() //add activate functions here
        {
            Activate();
        }
        void Activate()
        {
            foreach(Synapse syn in Synapses)
            {
                syn.Child.Value += this.Value * syn.Weight;
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

