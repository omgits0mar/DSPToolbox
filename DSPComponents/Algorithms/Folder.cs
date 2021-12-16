using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Folder : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputFoldedSignal { get; set; }

        public override void Run()
        {
            List<float> Samples_values = new List<float>();
            List<int> Sample_index = new List<int>();
            //if (Algorithm.check_shifting == true) // mfrod false
            //{
                for (int i = InputSignal.Samples.Count - 1; i >= 0; i--)    // Reversed indicies
                {

                    Sample_index.Add(InputSignal.SamplesIndices[i] *= -1);
                    Samples_values.Add(InputSignal.Samples[i]);

                }

            //}
            /*else
            {
                for (int i = 0; i < InputSignal.Samples.Count; i++)
                {
                    Sample_index.Add(InputSignal.SamplesIndices[i]);
                    Samples_values.Add(InputSignal.Samples[InputSignal.Samples.Count-1-i]);

                }
            }*/
            OutputFoldedSignal = new Signal(Samples_values, Sample_index, false);
            Algorithm.check_folding= true;
        }
    }
}
