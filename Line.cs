using System.Drawing;

namespace SVGCreator;

public class Line : Shape
{
    public Point Start { get; set; }
    public Point End { get; set; }
    public Color StrokeColor { get; set; }
    public int StrokeWidth { get; set; }

    public Line(Point start, Point end, Color strokeColor, int strokeWidth)
    {
        this.Start = start;
        this.End = end;
        this.StrokeColor = strokeColor;
        this.StrokeWidth = strokeWidth;
    }

    public string ToSvgString(Point? origin)
    {
        if (origin == null)
        {
            return $@"<line x1=""{this.Start.X}"" y1=""{this.Start.Y}"" x2=""{this.End.X}"" y2=""{this.End.Y}"" stroke=""{this.StrokeColor.Name}"" stroke-width=""{this.StrokeWidth}"" />";
        }
        return $@"<line x1=""{origin.X + this.Start.X}"" y1=""{origin.Y + this.Start.Y}"" x2=""{origin.X + this.End.X}"" y2=""{origin.Y + this.End.Y}"" stroke=""{this.StrokeColor.Name}"" stroke-width=""{this.StrokeWidth}"" />";
    }
}
