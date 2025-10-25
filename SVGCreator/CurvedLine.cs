using System.Drawing;

namespace SVGCreator;

public class CurvedLine(List<(int, int)> points, Color strokeColor, int strokeWidth): Shape
{
    private List<(int x, int y)> Points { get; } = points;
    private Color StrokeColor { get; } = strokeColor;
    private int StrokeWidth { get; } = strokeWidth;
    
    public string ToSvgString(Point origin)
    {
        return $@"<polyline points=""{string.Join(" ", Points.Select(p => $"{origin.X + p.x},{origin.Y + p.y}"))}"" stroke=""{StrokeColor.Name}"" stroke-width=""{StrokeWidth}"" fill=""none"" />";
    }
}