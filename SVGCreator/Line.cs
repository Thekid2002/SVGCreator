using System.Drawing;

namespace SVGCreator;

public class Line((int sx, int sy) start, (int ex, int ey) end, Color? strokeColor, int? strokeWidth) : Shape
{
    private (int x, int y) Start { get; } = start;
    private (int x, int y) End { get; } = end;
    private Color StrokeColor { get; set; } = strokeColor ?? Color.Black;
    private int StrokeWidth { get; set; } = strokeWidth ?? 1;

    public string ToSvgString(Point? origin)
    {
        if (origin == null)
        {
            return $@"<line x1=""{Start.x}"" y1=""{Start.y}"" x2=""{End.x}"" y2=""{End.y}"" stroke=""{this.StrokeColor.Name}"" stroke-width=""{this.StrokeWidth}"" />";
        }
        return $@"<line x1=""{origin.X + Start.x}"" y1=""{origin.Y + Start.y}"" x2=""{origin.X + End.x}"" y2=""{origin.Y + End.y}"" stroke=""{this.StrokeColor.Name}"" stroke-width=""{StrokeWidth}"" />";
    }
}
