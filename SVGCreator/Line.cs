using System.Drawing;

namespace SVGCreator;

public class Line((int x, int y) start, (int x, int y) end, Color? strokeColor, int? strokeWidth, string? additionalAttributesString = null) : IShape
{
    private (int x, int y) Start { get; } = start;
    private (int x, int y) End { get; } = end;
    private Color? StrokeColor { get; } = strokeColor;
    private int? StrokeWidth { get; } = strokeWidth;
    private string? AdditionalAttributesString { get; } = additionalAttributesString;

    public string ToSvgString()
    {
        var attrs = new List<string>
        {
            $"x1=\"{Start.x}\"",
            $"y1=\"{Start.y}\"",
            $"x2=\"{End.x}\"",
            $"y2=\"{End.y}\""
        };

        if (StrokeColor.HasValue)
            attrs.Add($"stroke=\"{StrokeColor.Value.Name}\"");

        if (StrokeWidth.HasValue)
            attrs.Add($"stroke-width=\"{StrokeWidth.Value}\"");

        if (!string.IsNullOrEmpty(AdditionalAttributesString))
            attrs.Add(AdditionalAttributesString!);

        return $"<line {string.Join(" ", attrs)} />";
    }
}