using System.Drawing;

namespace SVGCreator;

public interface ISvgDocument
{
    SvgDocument SetWidth(int width);
    SvgDocument SetHeight(int height);
    SvgDocument AddCircle(int cx, int cy, int radius, Color? fillColor, Color? strokeColor, int? strokeWidth);
    string ToString();
}