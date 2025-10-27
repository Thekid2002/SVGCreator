using System.Drawing;

namespace SVGCreator;

public class Text(
    string content,
    (int x, int y) center,
    int fontSize,
    string? fontFamily,
    int? rotation,
    Color? fillColor,
    Color? strokeColor,
    int? strokeWidth,
    string? additionalAttributesString = null) : IShape
{
    private string Content { get; } = content;
    private (int x, int y) Center { get; } = center;
    private int FontSize { get; } = fontSize;
    private string? FontFamily { get; } = fontFamily;
    private int? Rotation { get; } = rotation;
    private Color? FillColor { get; } = fillColor;
    private Color? StrokeColor { get; } = strokeColor;
    private int? StrokeWidth { get; } = strokeWidth;
    private string? AdditionalAttributesString { get; } = additionalAttributesString;

    public string ToSvgString()
    {
        var attrs = new List<string>
        {
            $"x=\"{Center.x}\"",
            $"y=\"{Center.y}\"",
            $"font-size=\"{FontSize}\"",
            "text-anchor=\"middle\"",
            "dominant-baseline=\"middle\""
        };
        
        if (!string.IsNullOrEmpty(FontFamily))
            attrs.Add($"font-family=\"{FontFamily}\"");
        
        if (Rotation.HasValue)
            attrs.Add($"transform=\"rotate({Rotation.Value} {Center.x} {Center.y})\"");

        if (FillColor.HasValue)
            attrs.Add($"fill=\"{FillColor.Value.Name}\"");

        if (StrokeColor.HasValue)
            attrs.Add($"stroke=\"{StrokeColor.Value.Name}\"");

        if (StrokeWidth.HasValue)
            attrs.Add($"stroke-width=\"{StrokeWidth.Value}\"");

        if (!string.IsNullOrEmpty(AdditionalAttributesString))
            attrs.Add(AdditionalAttributesString!);

        return $@"<text {string.Join(" ", attrs)}>{Content}</text>";
    }
}