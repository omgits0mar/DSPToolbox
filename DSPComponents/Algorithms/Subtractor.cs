using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Subtractor : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public Signal OutputSignal { get; set; }

        /// <summary>
        /// To do: Subtract Signal2 from Signal1 
        /// i.e OutSig = Sig1 - Sig2 
        /// </summary>
        public override void Run()
        {
            List<float> Samples1 = new List<float>();
            List<float> Samples2= new List<float>();
            OutputSignal = new Signal(Samples1, true);
            float samples1,samples2;
            Signal name = new Signal(Samples2, true);

            for (int i = 0; i < InputSignal2.Samples.Count(); i++)
            {
                samples2 = InputSignal2.Samples[i] * -1;
                Samples2.Add(samples2);
                samples1 = InputSignal1.Samples[i] + name.Samples[i];
                Samples1.Add(samples1);
            }

        }
    }
}