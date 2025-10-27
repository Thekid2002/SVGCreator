using System.Drawing;

namespace SVGCreator;

public class Circle((int x, int y) center, int radius, Color? fillColor, Color? strokeColor, int? strokeWidth, string?  additionalAttributesString = null) : IShape
{
    private (int x, int y) Center { get; } = center;
    private int Radius { get; } = radius;
    private Color? FillColor { get; } = fillColor;
    private Color? StrokeColor { get; } = strokeColor;
    private int? StrokeWidth { get; } = strokeWidth;
    private string? AdditionalAttributesString { get; } = additionalAttributesString;
    
    public string ToSvgString()
    {
        var attrs = new List<string>
        {
            $"cx=\"{Center.x}\"",
            $"cy=\"{Center.y}\"",
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