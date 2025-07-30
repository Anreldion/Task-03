using System;
namespace Shapes.Extensions;

public static class DoubleExtensions
{
    public static bool EqualTo(this double a, double b, double tolerance = 0.01)
        => Math.Abs(a - b) < tolerance;
}