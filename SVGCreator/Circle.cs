using System.Drawing;

namespace SVGCreator;

public class Circle(int cx, int cy, int radius, Color? fillColor, Color? strokeColor, int? strokeWidth) : Shape
{
    private int Cx { get; } = cx;
    private int Cy { get; } = cy;
    private int Radius { get; } = radius;
    private Color FillColor { get; } = fillColor ?? Color.Black;
    private Color StrokeColor { get; } = strokeColor ?? Color.Black;
    private int StrokeWidth { get; } = strokeWidth ?? 0;

    public string ToSvgString(Point? origin)
    {
        if(origin == null)
        {
            return $@"<circle cx=""{Cx}"" cy=""{Cy}"" r=""{Radius}"" stroke=""{StrokeColor.Name}"" stroke-width=""{StrokeWidth}"" fill=""{FillColor.Name}"" />";
        }

        return $@"<circle cx=""{origin.X + Cx}"" cy=""{origin.Y + Cy}"" r=""{Radius}"" stroke=""{StrokeColor.Name}"" stroke-width=""{StrokeWidth}"" fill=""{FillColor.Name}"" />";
    }
}
