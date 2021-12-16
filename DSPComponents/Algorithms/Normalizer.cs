using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Normalizer : Algorithm
    {
        public Signal InputSignal { get; set; }
        public float InputMinRange { get; set; }
        public float InputMaxRange { get; set; }
        public Signal OutputNormalizedSignal { get; set; }

        public override void Run()
        {
            List<float> Samples = new List<float>();
            float sample;
            OutputNormalizedSignal = new Signal(Samples, true);
            int i = 0;
            while(i<InputSignal.Samples.Count)
            {
                sample = (InputMaxRange - InputMinRange) * (InputSignal.Samples[i] - InputSignal.Samples.Min()) /
                      (InputSignal.Samples.Max() - InputSignal.Samples.Min()) + InputMinRange;

                Samples.Add(sample);

                i++;
            }
        }
    }
}
