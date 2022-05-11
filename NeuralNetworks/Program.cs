using System;

namespace NeuralNetworks
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = new double[5] {1, 2, 3, 4, 5};
            Console.WriteLine("Start...");
            var WhiteNet = new NeuralNet(5, 10, 100, 10);
            double[] result = WhiteNet.GetResult(input);
            foreach (double res in result)
                Console.WriteLine(res);
            Console.WriteLine("Hello World!");
        }
    }
}
