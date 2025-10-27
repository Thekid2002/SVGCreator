using System.Drawing;

namespace SVGCreator;

public class Rectangle((int x, int y) centrum, int width, int height, Color? fillColor, Color? strokeColor, int? strokeWidth, string? additionalAttributesString = null) : Shape
{
    private (int x, int y) Centrum { get; } = centrum;
    private int Width { get; } = width;
    private int Height { get; } = height;
    private Color? FillColor { get; } = fillColor;
    private Color? StrokeColor { get; } = strokeColor;
    private int? StrokeWidth { get; } = strokeWidth;
    private string? AdditionalAttributesString { get; } = additionalAttributesString;

    public string ToSvgString(Point? origin)
    {
        int ox = origin?.X ?? 0;
        int oy = origin?.Y ?? 0;

        int halfW = Width / 2;
        int halfH = Height / 2;
        int x = ox + Centrum.x - halfW;
        int y = oy + Centrum.y - halfH;

        var attrs = new List<string>
        {
            $"x=\"{x}\"",
            $"y=\"{y}\"",
            $"width=\"{Width}\"",
            $"height=\"{Height}\""
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