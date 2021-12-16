using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class QuantizationAndEncoding : Algorithm
    {
        // You will have only one of (InputLevel or InputNumBits), the other property will take a negative value
        // If InputNumBits is given, you need to calculate and set InputLevel value and vice versa
        public int InputLevel { get; set; }
        public int InputNumBits { get; set; }
        public Signal InputSignal { get; set; }
        public Signal OutputQuantizedSignal { get; set; }
        public List<int> OutputIntervalIndices { get; set; }
        public List<string> OutputEncodedSignal { get; set; }
        public List<float> OutputSamplesError { get; set; }

        public override void Run()
        {
            float delta = 0;
            if (InputNumBits <= 0)  //lw msh mdini num bits
            {
                delta = (InputSignal.Samples.Max() - InputSignal.Samples.Min()) / InputLevel; // delta = (max - min / lvl)
                InputNumBits = Math.Abs((int)Math.Log(InputLevel, 2));  // no. of bits = Log base 
            }
            else if (InputLevel <= 0) // lw msh mdini input lvl
            {
                InputLevel = (int)Math.Pow(2, InputNumBits); //3ks bta3ha
                delta = (InputSignal.Samples.Max() - InputSignal.Samples.Min()) / InputLevel;
            }



            List<float> MidPoints = new List<float>();
            List<float> QSignal = new List<float>();
            OutputIntervalIndices = new List<int>();
            OutputEncodedSignal = new List<string>();
            OutputSamplesError = new List<float>();

            List<float> a = new List<float>(); //min
            List<float> b = new List<float>(); //max

            float min = InputSignal.Samples.Min();

            // calcculate midpoints
            for (int i = 0; i <= InputLevel; i++)
            {
                a.Add((float)Math.Round(min * 100f) / 100f);    // by rounding 3shan test case
                b.Add((float)Math.Round((min + delta) * 100f) / 100f);

                MidPoints.Add((min + min + delta) / 2);
                min = min + delta;
            }

            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {

                for (int j = 1; j <= a.Count; j++)
                {

                    if (InputSignal.Samples[i] >= a[j] && InputSignal.Samples[i] <= b[j]) //lw akbar men min w asghar men max sayvhom
                    {
                        OutputIntervalIndices.Add(j);
                        break;
                    }
                }
                QSignal.Add(MidPoints[OutputIntervalIndices[i] - 1]);
                OutputSamplesError.Add(QSignal[i] - InputSignal.Samples[i]);
                OutputEncodedSignal.Add(Convert.ToString(OutputIntervalIndices[i] - 1, 2).PadLeft(InputNumBits, '0'));

            }

            OutputQuantizedSignal = new Signal(QSignal, true);


        }
    }
}
