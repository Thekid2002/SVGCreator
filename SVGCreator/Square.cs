using System.Drawing;

namespace SVGCreator;

public class Square : Shape
{
    public Point TopLeft { get; set; }
    public int SideLength { get; set; }
    public Color? FillColor { get; set; }
    public Color? StrokeColor { get; set; }
    public int? StrokeWidth { get; set; }

    public Square(Point topLeft, int sideLength, Color? fillColor, Color? strokeColor, int? strokeWidth)
    {
        this.TopLeft = topLeft;
        this.SideLength = sideLength;
        this.FillColor = fillColor;
        this.StrokeColor = strokeColor;
        this.StrokeWidth = strokeWidth;
    }

    public string ToSvgString(Point? origin)
    {
        if (origin == null)
        {
            return $@"<rect x=""{this.TopLeft.X}"" y=""{this.TopLeft.Y}"" width=""{this.SideLength}"" height=""{this.SideLength}"" stroke=""{this.StrokeColor?.Name}"" stroke-width=""{this.StrokeWidth}"" fill=""{this.FillColor?.Name}"" />";
        }
        return $@"<rect x=""{origin.X + this.TopLeft.X}"" y=""{origin.Y + this.TopLeft.Y}"" width=""{this.SideLength}"" height=""{this.SideLength}"" stroke=""{this.StrokeColor?.Name}"" stroke-width=""{this.StrokeWidth}"" fill=""{this.FillColor?.Name}"" />";
    }
}
