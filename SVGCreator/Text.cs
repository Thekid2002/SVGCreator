using System.Drawing;

namespace SVGCreator;

public class Text(
    string content,
    (int x, int y) centrum,
    int fontSize,
    string fontFamily,
    Color? fillColor,
    Color? strokeColor,
    int? strokeWidth)
    : Shape
{
    private string Content { get; set; } = content;
    private (int x, int y) Centrum { get; set; } = centrum;
    private int FontSize { get; set; } = fontSize;
    private string FontFamily { get; set; } = fontFamily;
    private Color? FillColor { get; set; } = fillColor;
    private Color? StrokeColor { get; set; } = strokeColor;
    private int? StrokeWidth { get; set; } = strokeWidth;

    public string ToSvgString(Point? origin)
    {
        if (origin == null)
        {
            return $@"<text x=""{Centrum.x}"" y=""{Centrum.y}"" font-size=""{FontSize}"" font-family=""{FontFamily}"" fill=""{FillColor?.Name}"" stroke=""{StrokeColor?.Name}"" stroke-width=""{StrokeWidth}"" text-anchor=""middle"" dominant-baseline=""middle"">{Content}</text>";
        }
        return $@"<text x=""{origin.X + Centrum.x}""  y=""{origin.Y + Centrum.y}"" font-size=""{FontSize}"" font-family=""{FontFamily}"" fill=""{FillColor?.Name}"" stroke=""{StrokeColor?.Name}"" stroke-width=""{StrokeWidth}"" text-anchor=""middle"" dominant-baseline=""middle"">{Content}</text>";
    }
}
