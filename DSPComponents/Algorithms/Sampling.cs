using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class Sampling : Algorithm
    {
        public int L { get; set; } //upsampling factor
        public int M { get; set; } //downsampling factor
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }
        
        


        public override void Run()
        {
            
            FIR FIR = new FIR();
            int Sample_size = L * InputSignal.Samples.Count;
            int add=1,counter=0;
            int empty = 0;
            List<float> Samples_values = new List<float>();
            FIR.InputFilterType = FILTER_TYPES.LOW;
            FIR.InputFS = 8000;
            FIR.InputStopBandAttenuation = 50;
            FIR.InputCutOffFrequency = 1500;
            FIR.InputTransitionBand = 500;
            void UpSampling(int L)
            {
                for (int i = 0; i < Sample_size; i++)
                {
                    if (i % L == 0)
                    {
                        Samples_values.Add(InputSignal.Samples[counter]);
                        counter++;
                    }
                    else
                    {
                        Samples_values.Add(empty);
                    }
                }
            }
            if( M == 0 && L != 0)   // Upsampling then Low Pass
            {
                
                UpSampling(L);
                FIR.InputTimeDomainSignal = new Signal(Samples_values, false);
                FIR.Run();
                OutputSignal = FIR.OutputYn;
            }
            else if( M != 0 && L == 0)  // LowPass then Downsampling
            {
                FIR.InputTimeDomainSignal = InputSignal;
                FIR.Run();
                OutputSignal = new Signal(new List<float>(), false);
                for (int j = 0; j < FIR.OutputYn.Samples.Count; j += M)
                {
                    OutputSignal.Samples.Add(FIR.OutputYn.Samples[j]);
                }
            }
            else if( M != 0 && L != 0)  //UpSampling then LowPass then DownSampling
            {
                UpSampling(L);
                FIR.InputTimeDomainSignal = new Signal(Samples_values, false);
                FIR.Run();
                OutputSignal = new Signal(new List<float>(), false);
                for(int j = 0; j < FIR.OutputYn.Samples.Count; j+= M)
                {
                    OutputSignal.Samples.Add(FIR.OutputYn.Samples[j]);   
                }
            }
            else
            {
                throw new Exception("fssssss");
            }
           /* FIR.InputTimeDomainSignal = sig1;

            FIR.Run();*/
        }
    }
    
}
