using System.Drawing;

namespace SVGCreator;

public class Circle(int cx, int cy, int radius, Color? fillColor, Color? strokeColor, int? strokeWidth, string?  additionalAttributesString = null) : Shape
{
    private int Cx { get; } = cx;
    private int Cy { get; } = cy;
    private int Radius { get; } = radius;
    private Color? FillColor { get; } = fillColor;
    private Color? StrokeColor { get; } = strokeColor;
    private int? StrokeWidth { get; } = strokeWidth;
    private string? AdditionalAttributesString { get; } = additionalAttributesString;
    
    public string ToSvgString(Point? origin)
    {
        int cx = (origin?.X ?? 0) + Cx;
        int cy = (origin?.Y ?? 0) + Cy;

        var attrs = new List<string>
        {
            $"cx=\"{cx}\"",
            $"cy=\"{cy}\"",
            $"r=\"{Radius}\""
        };

        if (StrokeColor.HasValue)
            attrs.Add($"stroke=\"{StrokeColor.Value.Name}\"");

        if (StrokeWidth.HasValue)
            attrs.Add($"stroke-width=\"{StrokeWidth.Value}\"");

        if (FillColor.HasValue)
            attrs.Add($"fill=\"{FillColor.Value.Name}\"");
        
        if (!string.IsNullOrEmpty(AdditionalAttributesString))
            attrs.Add(AdditionalAttributesString!);

        return $"<circle {string.Join(" ", attrs)} />";
    }
}