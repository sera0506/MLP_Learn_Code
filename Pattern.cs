using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLP_hw2
{
    class Pattern
    {
        private double[] _inputs;
        private double _output;

        public Pattern(string value, int inputSize)
        {
            string[] line = value.Trim().Split(',');
            if (line.Length - 1 != inputSize)
            {
                Console.WriteLine("line : " + line.Length + " inpuD : " + inputSize);
                throw new Exception("Input does not match network configuration");
            }
            _inputs = new double[inputSize];
            for (int i = 0; i < inputSize; i++)
            {
                _inputs[i] = double.Parse(line[i]);
            }
            _output = double.Parse(line[inputSize].Trim());
        }

        public double[] Inputs
        {

            get { return _inputs; }
        }

        public double Output
        {
            get { return _output; }
        }
    }
}
