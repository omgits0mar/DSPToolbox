using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class SinCos: Algorithm
    {
        public string type { get; set; }
        public float A { get; set; }
        public float PhaseShift { get; set; }
        public float AnalogFrequency { get; set; }
        public float SamplingFrequency { get; set; }
        public List<float> samples { get; set; }
        public override void Run()
        {
            // A * [sin او cos] (2*π*(analog frequency/sampling frequency)*n + phase shift)
            samples = new List<float>();
            float frequency = AnalogFrequency / SamplingFrequency;
            if (type == "sin")
            {
                List<float> sinusoidal = new List<float>();
                for (int i = 0; i < SamplingFrequency; i++)
                    sinusoidal.Add((float)(A * Math.Sin(2 * Math.PI * frequency * i + PhaseShift)));
                samples = sinusoidal;

            }
            else
            {
                List<float> cosinusoidal = new List<float>();
                for (int i = 0; i < SamplingFrequency; i++)
                    cosinusoidal.Add((float)(A * Math.Cos(2 * Math.PI * frequency * i + PhaseShift)));
                samples = cosinusoidal;
            }
        }
    }
}
