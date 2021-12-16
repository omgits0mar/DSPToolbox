using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Shifter : Algorithm
    {
        public Signal InputSignal { get; set; }
        public int ShiftingValue { get; set; }
        public Signal OutputShiftedSignal { get; set; }

        public override void Run()
        {
            List<float> Samples_values = new List<float>();
            List<int> Sample_index = new List<int>();
            if (Algorithm.check_folding == false)
            {
                for (int i = 0; i < InputSignal.Samples.Count; i++)    // +ve (minus el value of shifter) wel 3ks
                {
                    Sample_index.Add(InputSignal.SamplesIndices[i] -= ShiftingValue);
                    Samples_values.Add(InputSignal.Samples[i]);

                }
            }
            else 
            {
                for (int i = 0; i < InputSignal.Samples.Count; i++)    // +ve (minus el value of shifter) wel 3ks
                {
                    Sample_index.Add(InputSignal.SamplesIndices[i] -= (ShiftingValue*-1));
                    Samples_values.Add(InputSignal.Samples[i]);

                }
            }
            OutputShiftedSignal = new Signal(Samples_values, Sample_index, false);

        }
    }
}
