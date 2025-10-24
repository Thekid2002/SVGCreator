using System.Drawing;

namespace SVGCreator;

public class Text : Shape
{
    public string Content { get; set; }
    public Point TopLeft { get; set; }
    public int FontSize { get; set; }
    public string FontFamily { get; set; }
    public Color? FillColor { get; set; }
    public Color? StrokeColor { get; set; }
    public int? StrokeWidth { get; set; }

    public Text(string content, Point topLeft, int fontSize, string fontFamily, Color? fillColor, Color? strokeColor, int? strokeWidth)
    {
        this.Content = content;
        this.TopLeft = topLeft;
        this.FontSize = fontSize;
        this.FontFamily = fontFamily;
        this.FillColor = fillColor;
        this.StrokeColor = strokeColor;
        this.StrokeWidth = strokeWidth;
    }

    public string ToSvgString(Point? origin)
    {
        if (origin == null)
        {
            return $@"<text x=""{this.TopLeft.X}"" y=""{this.TopLeft.Y}"" font-size=""{this.FontSize}"" font-family=""{this.FontFamily}"" fill=""{this.FillColor?.Name}"" stroke=""{this.StrokeColor?.Name}"" stroke-width=""{this.StrokeWidth}"">{this.Content}</text>";
        }
        return $@"<text x=""{origin.X + this.TopLeft.X}"" y=""{origin.Y + this.TopLeft.Y}"" font-size=""{this.FontSize}"" font-family=""{this.FontFamily}"" fill=""{this.FillColor?.Name}"" stroke=""{this.StrokeColor?.Name}"" stroke-width=""{this.StrokeWidth}"">{this.Content}</text>";
    }
}
