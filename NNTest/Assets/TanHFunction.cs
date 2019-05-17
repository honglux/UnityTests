using AForge.Neuro;
using System;

public class TanHFunction : IActivationFunction, ICloneable
{
    const float e = 2.718f;

    public TanHFunction()
    {

    }

    public double Derivative(double x)
    {
        return 1 - Math.Pow(Function(x),2.0f);
    }

    public double Derivative2(double y)
    {
        return 1 - Math.Pow(Function(y), 2.0f);
    }

    public double Function(double x)
    {
        double epx_m_ep_x = Math.Pow(e, x) - Math.Pow(e, -x);
        double exp_p_ep_x = Math.Pow(e, x) + Math.Pow(e, -x);

        return epx_m_ep_x/ exp_p_ep_x;
    }

    public object Clone()
    {
        return new TanHFunction();
    }
}
