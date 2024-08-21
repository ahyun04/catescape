using UnityEngine;

public static class GizmosExtensions
{

    /// <summary>
    /// Draws a wire arc in 2D space around the Z-axis.
    /// </summary>
    /// <param name="position">The center of the arc.</param>
    /// <param name="angleRange">The angle range of the arc in degrees.</param>
    /// <param name="radius">The radius of the arc.</param>
    /// <param name="color">The color of the arc.</param>
    /// <param name="maxSteps">How many steps to use to draw the arc.</param>
    public static void DrawWireArc(Vector2 position, float angleRange, float radius, Color color, float maxSteps = 20)
    {
        Gizmos.color = color;

        float startAngle = -angleRange / 2;
        float stepAngle = angleRange / maxSteps;
        Vector2 previousPoint = position + RadiusVector2(startAngle, radius);

        for (int i = 1; i <= maxSteps; i++)
        {
            float angle = startAngle + i * stepAngle;
            Vector2 currentPoint = position + RadiusVector2(angle, radius);
            Gizmos.DrawLine(previousPoint, currentPoint);
            previousPoint = currentPoint;
        }

        // Draw the final line to close the arc
        Gizmos.DrawLine(previousPoint, position + RadiusVector2(startAngle + angleRange, radius));
    }

    /// <summary>
    /// Draws a wire arc in 2D space with default color.
    /// </summary>
    /// <param name="position">The center of the arc.</param>
    /// <param name="angleRange">The angle range of the arc in degrees.</param>
    /// <param name="radius">The radius of the arc.</param>
    /// <param name="maxSteps">How many steps to use to draw the arc.</param>
    public static void DrawWireArc(Vector2 position, float angleRange, float radius, float maxSteps = 20)
    {
        DrawWireArc(position, angleRange, radius, Color.red, maxSteps);
    }

    private static Vector2 RadiusVector2(float angle, float radius)
    {
        // Calculate a point on the circle's circumference based on angle and radius
        float rad = Mathf.Deg2Rad * angle;
        return new Vector2(radius * Mathf.Cos(rad), radius * Mathf.Sin(rad));
    }
}
