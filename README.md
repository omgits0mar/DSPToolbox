# DSP Components

This repository contains a collection of C# codes for digital signal processing. The codes are organized into the following folders:

- DSPComponents/
  - Algorithms/
    - AccumulationSum.cs
    - Adder.cs
    - Algorithm.cs
    - DCT.cs
    - DC_Component.cs
    - Derivatives.cs
    - DirectConvolution.cs
    - DirectCorrelation.cs
    - DiscreteFourierTransform.cs
    - FIR.cs
    - FastConvolution.cs
    - FastCorrelation.cs
    - FastFourierTransform.cs
    - Folder.cs
    - InverseDiscreteFourierTransform.cs
    - inverseFastFourierTransform.cs
    - MovingAverage.cs
    - MultiplySignalByConstant.cs
    - Normalizer.cs
    - QuantizationAndEncoding.cs
    - Sampling.cs
    - Shifter.cs
    - SinCos.cs
    - Subtractor.cs
    - TimeDelay.cs
    - Utilities.cs
  - DataStructures/
  - Properties/

## Algorithms

This folder contains the implementation of various digital signal processing algorithms. Below is a brief description of each algorithm and how it processes the digital signal:

- `AccumulationSum.cs`: Calculates the running sum of a signal over time.

- `Adder.cs`: Adds two signals together.

- `Algorithm.cs`: Abstract class for defining the interface for signal processing algorithms.

- `DCT.cs`: Calculates the discrete cosine transform of a signal.

- `DC_Component.cs`: Calculates the DC component of a signal.

- `Derivatives.cs`: Calculates the derivative of a signal.

- `DirectConvolution.cs`: Calculates the convolution of two signals using the direct method.

- `DirectCorrelation.cs`: Calculates the correlation of two signals using the direct method.

- `DiscreteFourierTransform.cs`: Calculates the discrete Fourier transform of a signal.

- `FIR.cs`: Calculates the convolution of a signal with a finite impulse response filter.

- `FastConvolution.cs`: Calculates the convolution of two signals using the fast Fourier transform.

- `FastCorrelation.cs`: Calculates the correlation of two signals using the fast Fourier transform.

- `FastFourierTransform.cs`: Calculates the fast Fourier transform of a signal.

- `Folder.cs`: Inverts the signal.

- `InverseDiscreteFourierTransform.cs`: Calculates the inverse discrete Fourier transform of a signal.

- `inverseFastFourierTransform.cs`: Calculates the inverse fast Fourier transform of a signal.

- `MovingAverage.cs`: Calculates the moving average of a signal.

- `MultiplySignalByConstant.cs`: Multiplies a signal by a constant.

- `Normalizer.cs`: Normalizes a signal to have zero mean and unit variance.

- `QuantizationAndEncoding.cs`: Quantizes and encodes a signal.

- `Sampling.cs`: Samples a continuous signal at regular intervals.

- `Shifter.cs`: Shifts a signal by a given time delay.

- `SinCos.cs`: Calculates the sine and cosine of a signal.

- `Subtractor.cs`: Subtracts one signal from another.

- `TimeDelay.cs`: Delays a signal by a given time delay.

- `Utilities.cs`: Utility functions for digital signal processing.

## Unit Tests

The DSPComponentsUnitTest folder contains multiple unit test .cs files for the algorithms in the DSPComponents folder. These unit tests ensure that the algorithms are functioning correctly and producing the expected output for various input signals. 

## References

- Oppenheim, A. V., & Schafer, R. W. (2010). *Discrete-time signal processing*. Prentice Hall.
