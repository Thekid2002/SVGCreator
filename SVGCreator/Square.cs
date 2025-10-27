using System.Drawing;

namespace SVGCreator;

public class Square((int x, int y) center, int sideLength, Color? fillColor, Color? strokeColor, int? strokeWidth, string? additionalAttributesString = null) : Shape
{
    private (int x, int y) Center { get; } = center;
    private int SideLength { get; } = sideLength;
    private Color? FillColor { get; } = fillColor;
    private Color? StrokeColor { get; } = strokeColor;
    private int? StrokeWidth { get; } = strokeWidth;
    private string? AdditionalAttributesString { get; } = additionalAttributesString;

    public string ToSvgString(Point? origin)
    {
        int ox = origin?.X ?? 0;
        int oy = origin?.Y ?? 0;

        int half = SideLength / 2;
        int x = ox + Center.x - half;
        int y = oy + Center.y - half;

        var attrs = new List<string>
        {
            $"x=\"{x}\"",
            $"y=\"{y}\"",
            $"width=\"{SideLength}\"",
            $"height=\"{SideLength}\""
        };

        if (StrokeColor.HasValue)
            attrs.Add($"stroke=\"{StrokeColor.Value.Name}\"");

        if (StrokeWidth.HasValue)
            attrs.Add($"stroke-width=\"{StrokeWidth.Value}\"");

        if (FillColor.HasValue)
            attrs.Add($"fill=\"{FillColor.Value.Name}\"");

        if (!string.IsNullOrEmpty(AdditionalAttributesString))
            attrs.Add(AdditionalAttributesString!);

        return $"<rect {string.Join(" ", attrs)} />";
    }
}