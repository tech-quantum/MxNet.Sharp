﻿using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxNet.Gluon.NN
{
    public class DeformableConvolution : HybridBlock
    {
        public DeformableConvolution(int channels, (int, int)? kernel_size = null, (int, int)? strides = null, (int, int)? padding = null, (int, int)? dilation = null,
            int groups = 1, int num_deformable_group = 1, string layout = "NCHW", bool use_bias = true, int in_channels = 0, ActivationType? activation = null,
            Initializer weight_initializer = null, string bias_initializer = "zeros", bool offset_use_bias = true, int[] adj = null,
            string op_name = "DeformableConvolution")
        {
            throw new NotImplementedException();
        }

        public override string Alias()
        {
            return "deformable_conv";
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            return base.HybridForward(x, args);
        }
    }
}