using UnityEngine;

public static class Utilities
{

    /// <summary>
    /// Calculate the Bezeier cubic curve;
    /// Equation:
    /// f(x) = A*(1-x^3)*P0+B*(1-x)^2*x*P1+C*(1-x)*x^2*P2+D*x^3*P3, 0<=x<=1
    /// </summary>
    /// <returns></returns>
    public static Vector3 BCubeCurveCal(float A, float B, float C, float D, Vector3 p0, Vector3 p1,
        Vector3 p2, Vector3 p3, float x)
    {
        Vector3 res = A * Mathf.Pow((1 - x), 3) * p0 + B * Mathf.Pow((1 - x), 2) * x * p1 +
                C * (1 - x) * Mathf.Pow(x, 2) * p2 + D * Mathf.Pow(x, 3) * p3;
        return res;
    }

    /// <summary>
    /// Calculate the Bezeier Quad curve;
    /// Equation:
    /// f(x) = A*P1 + B*((1-x)^2)*(P0 - P1) + C*(x^2)*(P2-P1), 0<=x<=1
    /// </summary>
    /// <returns></returns>
    public static Vector3 BQuadCurveCal(float A, float B, float C, Vector3 p0, Vector3 p1, Vector3 p2,
        float x)
    {
        Vector3 res = A*p1 + B*Mathf.Pow((1 - x), 2) * (p0 - p1) + C*Mathf.Pow(x, 2) * (p2 - p1);
        return res;
    }

    /// <summary>
    /// Calculate the rotation of LookAt for 2d. The original rotation need to face up;
    /// </summary>
    /// <param name="position"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static Quaternion TowDLookAt(Vector3 position, Vector3 target)
    {
        Vector3 dir = (target - position).normalized;

        float rot_z = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        return Quaternion.Euler(0f, 0f, rot_z - 90.0f);
    }
}
