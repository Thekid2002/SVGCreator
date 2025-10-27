using System.Drawing;

namespace SVGCreator;

public class CurvedLine(List<(int x, int y)> points, Color? strokeColor, int? strokeWidth, string? additionalAttributesString = null) : Shape
{
    private List<(int x, int y)> Points { get; } = points;
    private Color? StrokeColor { get; } = strokeColor;
    private int? StrokeWidth { get; } = strokeWidth;
    private string? AdditionalAttributesString { get; } = additionalAttributesString;

    public string ToSvgString(Point? origin)
    {
        int ox = origin?.X ?? 0;
        int oy = origin?.Y ?? 0;

        var attrs = new List<string>
        {
            $"points=\"{string.Join(" ", Points.Select(p => $"{ox + p.x},{oy + p.y}"))}\""
        };

        if (StrokeColor.HasValue)
            attrs.Add($"stroke=\"{StrokeColor.Value.Name}\"");

        if (StrokeWidth.HasValue)
            attrs.Add($"stroke-width=\"{StrokeWidth.Value}\"");
        
        if (!string.IsNullOrEmpty(AdditionalAttributesString))
            attrs.Add(AdditionalAttributesString!);

        return $"<polyline {string.Join(" ", attrs)} />";
    }
}