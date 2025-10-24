using System.Drawing;

namespace SVGCreator;

public class Text(
    string content,
    (int x, int y) topLeft,
    int fontSize,
    string fontFamily,
    Color? fillColor,
    Color? strokeColor,
    int? strokeWidth)
    : Shape
{
    private string Content { get; set; } = content;
    private (int x, int y) TopLeft { get; set; } = topLeft;
    private int FontSize { get; set; } = fontSize;
    private string FontFamily { get; set; } = fontFamily;
    private Color? FillColor { get; set; } = fillColor;
    private Color? StrokeColor { get; set; } = strokeColor;
    private int? StrokeWidth { get; set; } = strokeWidth;

    public string ToSvgString(Point? origin)
    {
        if (origin == null)
        {
            return $@"<text x=""{this.TopLeft.x}"" y=""{this.TopLeft.y}"" font-size=""{this.FontSize}"" font-family=""{this.FontFamily}"" fill=""{this.FillColor?.Name}"" stroke=""{this.StrokeColor?.Name}"" stroke-width=""{this.StrokeWidth}"">{this.Content}</text>";
        }
        return $@"<text x=""{origin.X + this.TopLeft.x}"" y=""{origin.Y + this.TopLeft.y}"" font-size=""{this.FontSize}"" font-family=""{this.FontFamily}"" fill=""{this.FillColor?.Name}"" stroke=""{this.StrokeColor?.Name}"" stroke-width=""{this.StrokeWidth}"">{this.Content}</text>";
    }
}
