﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Optimizers
{
    public class SGD : Optimizer
    {
        private readonly Dictionary<int, NDArray> moments;

        public SGD(float momentum = 0, bool lazy_update = true)
        {
            throw new NotImplementedException();
        }

        public override object CreateState(int index, NDArray weight)
        {
            throw new NotImplementedException();
        }

        public override void Update(int iteration, int index, NDArray param, NDArray grad, object state)
        {
            throw new NotImplementedException();
        }
    }
}
