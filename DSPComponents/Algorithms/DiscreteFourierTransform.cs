using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DiscreteFourierTransform : Algorithm
    {
        public Signal InputTimeDomainSignal { get; set; }
        public float InputSamplingFrequency { get; set; }
        public Signal OutputFreqDomainSignal { get; set; }

        public override void Run()
        {
            //  InputTimeDomainSignal.Samples.Count = number of samples (N)
            double realNum,imaginaryNum;
            Complex sum;
            float amplitude,phase, freq;

            List<float> amplitudes = new List<float>();
            List<float> phases = new List<float>();
            List<float> Samples = new List<float>();
            List<float> Frequencies = new List<float>();
            List<Complex> sumList = new List<Complex>();

            for (int k = 0; k < InputTimeDomainSignal.Samples.Count; k++)
            {
                sum = new Complex(0, 0);
                for (int num = 0; num < InputTimeDomainSignal.Samples.Count; num++)     //num = itiration (n)
                {
                    imaginaryNum = (float)Math.Sin(2 * Math.PI * k * num / Convert.ToDouble(InputTimeDomainSignal.Samples.Count)); // sin
                    realNum = (float)Math.Cos(2 * Math.PI * k * num / Convert.ToDouble(InputTimeDomainSignal.Samples.Count)); // cos
                    Complex j = new Complex(realNum, -imaginaryNum); // bn7ot el imaginary -J

                    
                    j = Complex.Multiply(j, InputTimeDomainSignal.Samples[num]); // x(n) * e^j
                    sum = Complex.Add(sum, j); // adding summition x(n)


                }
                sumList.Add(sum); // tgm3hom wt7otohom f sample List gdida " Final Sample List " 

            }

            for (int num = 0; num < InputTimeDomainSignal.Samples.Count; num++)
            {
                amplitude = (float)Math.Sqrt(Math.Pow(sumList[num].Real, 2) + Math.Pow(sumList[num].Imaginary, 2)); //amplitude = root real^2 + imag^2
                
                phase = (float)Math.Atan2(sumList[num].Imaginary, sumList[num].Real); // phase = inv tan(imag/real)
                 

                amplitudes.Add(amplitude);
                phases.Add(phase);

            }
            for (int num = 1; num <= InputTimeDomainSignal.Samples.Count; num++)
            {
                freq = (float)((2 * Math.PI / (InputTimeDomainSignal.Samples.Count * (1 / InputSamplingFrequency))) * num);
                // freq= ( (2pie) / (N*T) ) * n
                Frequencies.Add(freq);
            }

            OutputFreqDomainSignal = new Signal(false, Frequencies, amplitudes, phases);

        }
    }
}
