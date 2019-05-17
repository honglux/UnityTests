using AForge.Neuro;
using System;

public class LinearFunction : IActivationFunction, ICloneable
{
    public LinearFunction()
    {

    }

    public double Derivative(double x)
    {
        return 1;
    }

    public double Derivative2(double y)
    {
        return 1;
    }

    public double Function(double x)
    {
        return x;
    }

    public object Clone()
    {
        return new LinearFunction();
    }
}
