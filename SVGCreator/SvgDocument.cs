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

    public SvgDocument AddCircle(int cx, int cy, int radius, Color? fillColor, Color? strokeColor, int? strokeWidth)
    {
        Shapes.Add(new Circle(cx, cy, radius, fillColor, strokeColor, strokeWidth));
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
