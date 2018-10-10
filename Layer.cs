﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MLP_hw2
{
    class Layer : List<Neuron>
    {
        public Layer(int size)
        {
            for (int i = 0; i < size; i++)
                base.Add(new Neuron());
        }

        public Layer(int size, Layer layer, Random rnd)
        {
            for (int i = 0; i < size; i++)
                base.Add(new Neuron(layer, rnd));
        }
    }
}
