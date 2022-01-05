using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class Derivatives: Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal FirstDerivative { get; set; }
        public Signal SecondDerivative { get; set; }

        public override void Run()
        {
            /* 
            1st = x(n)-x(n-1) 
            2nd = x(n+1)-2x(n)+x(n-1)
            */
            List<float> Samples1 = new List<float>();
            List<float> Samples2 = new List<float>();

            for (int i = 0; i < InputSignal.Samples.Count - 1; i++)
            {
                if (i == 0)
                {
                    Samples1.Add(InputSignal.Samples[i] - 0);
                    Samples2.Add(InputSignal.Samples[i + 1] - 2 * InputSignal.Samples[i] + 0);
                }
                else if (i == InputSignal.Samples.Count - 1)
                    Samples2.Add(0 - 2 * InputSignal.Samples[i] + InputSignal.Samples[i - 1]);
                else
                {
                    Samples1.Add(InputSignal.Samples[i] - InputSignal.Samples[i - 1]);
                    Samples2.Add(InputSignal.Samples[i + 1] - 2 * InputSignal.Samples[i] + InputSignal.Samples[i - 1]);
                }
            }
            FirstDerivative = new Signal(Samples1, false);
            SecondDerivative = new Signal(Samples2, false);

        }
    }
}
