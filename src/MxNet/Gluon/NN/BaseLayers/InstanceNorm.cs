﻿using MxNet.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxNet.Gluon.NN
{
    public class InstanceNorm : HybridBlock
    {
        public int Axis { get; }
        public float Epsilon { get; }
        public bool Center { get; }
        public bool Scale { get; }
        public int In_Channels { get; }
        public NDArray Gamma { get; set; }
        public NDArray Beta { get; set; }

        public InstanceNorm(int axis= 1, float epsilon= 1e-5f, bool center= true, bool scale= false,
                        string beta_initializer= "zeros", string gamma_initializer= "ones",
                        int in_channels= 0, string prefix = null, ParameterDict @params = null) : base(prefix, @params)
        {
            Axis = axis;
            Epsilon = epsilon;
            Center = center;
            Scale = scale;
            In_Channels = in_channels;
            Gamma = Params.Get("gamma", new Shape((uint)in_channels), Initializer.Get(gamma_initializer), allow_deferred_init: true, grad_req: scale ? OpGradReq.Write : OpGradReq.Null);
            Beta = Params.Get("beta", new Shape((uint)in_channels), Initializer.Get(beta_initializer), allow_deferred_init: true, grad_req: center ? OpGradReq.Write : OpGradReq.Null);
        }

        public override NDArrayOrSymbol HybridForward(NDArrayOrSymbol x, params NDArrayOrSymbol[] args)
        {
            NDArrayOrSymbol gamma = args[0];
            NDArrayOrSymbol beta = args[1];

            if (x.IsNDArray)
                return nd.InstanceNorm(x.NdX, gamma.NdX, beta.NdX, Epsilon);

            return sym.InstanceNorm(x.SymX, gamma.SymX, beta.SymX, Epsilon, symbol_name: "fwd");
        }
    }
}