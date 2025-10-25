using System.Drawing;

namespace SVGCreator;

public class SvgDocument(): ISvgDocument
{
    private int Width { get; set; }
    private int Height { get; set; }

    private List<Shape> Shapes { get; set; } = new();
    
    public SvgDocument SetWidth(int width)
    {
        Width = width;
        return this;
    }

    public SvgDocument SetHeight(int height)
    {
        Height = height;
        return this;
    }

    public SvgDocument AddCircle((int x, int y) center, int radius, Color? fillColor, Color? strokeColor, int? strokeWidth)
    {
        Shapes.Add(new Circle(center.x, center.y, radius, fillColor, strokeColor, strokeWidth));
        return this;
    }

    public SvgDocument AddLine((int x, int y) start, (int x, int y) end, Color strokeColor, int strokeWidth)
    {
        Shapes.Add(new Line(start, end, strokeColor, strokeWidth));
        return this;
    }

    public SvgDocument AddText(string content, (int x, int y) centrum, int fontSize, string fontFamily, Color? fillColor,
        Color? strokeColor, int? strokeWidth)
    {
        Shapes.Add(new Text(content, centrum, fontSize, fontFamily, fillColor, strokeColor, strokeWidth));
        return this;
    }


    public override string ToString()
    {
        return GenerateSVGString(Shapes);
    }

    private string GenerateSVGString(List<Shape> shapes)
    {
        string content = $@"<svg width=""{this.Width}"" height=""{this.Height}"" xmlns=""http://www.w3.org/2000/svg"">";

        foreach (var shape in shapes)
        {
            content += "    " + shape.ToSvgString(new Point(0,0)) + "\n";
        }
        content += "</svg>";
        return content;
    }
}
