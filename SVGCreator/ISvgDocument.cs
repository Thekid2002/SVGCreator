using System.Drawing;

namespace SVGCreator;

public interface ISvgDocument
{
    SvgDocument SetWidth(int width);
    SvgDocument SetHeight(int height);
    SvgDocument AddCircle((int x, int y) center, int radius, Color? fillColor, Color? strokeColor, int? strokeWidth);
    SvgDocument AddLine((int x, int y) start, (int x, int y) end, Color strokeColor, int strokeWidth);
    SvgDocument AddCurvedLine(List<(int, int)> points, Color strokeColor, int strokeWidth);
    SvgDocument AddText(string content, (int x, int y) topLeft, int fontSize, string fontFamily, Color? fillColor, Color? strokeColor, int? strokeWidth);
    string ToString();
}