using System.Drawing;

namespace SVGCreator;

public interface ISvgDocument
{
    SvgDocument SetWidth(int width);
    SvgDocument SetHeight(int height);
    SvgDocument AddCircle((int x, int y) center, int radius, Color? fillColor, Color? strokeColor, int? strokeWidth, string? additionalAttributesString = null);
    SvgDocument AddLine((int x, int y) start, (int x, int y) end, Color strokeColor, int strokeWidth, string? additionalAttributesString = null);
    SvgDocument AddCurvedLine(List<(int, int)> points, Color strokeColor, int strokeWidth, string? additionalAttributesString = null);
    SvgDocument AddText(string content, (int x, int y) center, int fontSize, string? fontFamily, int? rotation, Color? fillColor, Color? strokeColor, int? strokeWidth, string? additionalAttributesString = null);
    SvgDocument AddSquare((int x, int y) center, int sideLength, Color? fillColor, Color? strokeColor, int? strokeWidth, string? additionalAttributesString = null);
    SvgDocument AddRectangle((int x, int y) center, int width, int height, Color? fillColor, Color? strokeColor, int? strokeWidth, string? additionalAttributesString = null);
    SvgDocument AddShape(IShape shape);
    string ToString();
}