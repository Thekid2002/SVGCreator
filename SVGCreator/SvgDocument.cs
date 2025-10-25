using System.Drawing;

namespace SVGCreator;

/// <summary>
/// Represents an SVG document that can contain multiple shapes.
/// Provides a fluent interface to configure size and add shapes.
/// </summary>
public class SvgDocument: ISvgDocument
{
    /// <summary>
    /// The width of the SVG canvas.
    /// </summary>
    private int Width { get; set; }

    /// <summary>
    /// The height of the SVG canvas.
    /// </summary>
    private int Height { get; set; }

    /// <summary>
    /// List of shapes added to the SVG document.
    /// </summary>
    private List<Shape> Shapes { get; set; } = new();
    
    /// <summary>
    /// Sets the width of the SVG document.
    /// </summary>
    /// <param name="width">Width in pixels.</param>
    /// <returns>The current SvgDocument for chaining.</returns>
    public SvgDocument SetWidth(int width)
    {
        Width = width;
        return this;
    }

    /// <summary>
    /// Sets the height of the SVG document.
    /// </summary>
    /// <param name="height">Height in pixels.</param>
    /// <returns>The current SvgDocument for chaining.</returns>
    public SvgDocument SetHeight(int height)
    {
        Height = height;
        return this;
    }

    /// <summary>
    /// Adds a circle to the SVG document.
    /// </summary>
    /// <param name="center">Tuple representing the center coordinates of the circle.</param>
    /// <param name="radius">Radius of the circle.</param>
    /// <param name="fillColor">Fill color of the circle (optional).</param>
    /// <param name="strokeColor">Stroke color of the circle (optional).</param>
    /// <param name="strokeWidth">Stroke width (optional).</param>
    /// <returns>The current SvgDocument for chaining.</returns>
    public SvgDocument AddCircle((int x, int y) center, int radius, Color? fillColor, Color? strokeColor, int? strokeWidth)
    {
        Shapes.Add(new Circle(center.x, center.y, radius, fillColor, strokeColor, strokeWidth));
        return this;
    }

    /// <summary>
    /// Adds a straight line to the SVG document.
    /// </summary>
    /// <param name="start">Starting point of the line.</param>
    /// <param name="end">Ending point of the line.</param>
    /// <param name="strokeColor">Color of the line.</param>
    /// <param name="strokeWidth">Width of the line.</param>
    /// <returns>The current SvgDocument for chaining.</returns>
    public SvgDocument AddLine((int x, int y) start, (int x, int y) end, Color strokeColor, int strokeWidth)
    {
        Shapes.Add(new Line(start, end, strokeColor, strokeWidth));
        return this;
    }
    
    /// <summary>
    /// Adds a curved line defined by multiple points to the SVG document.
    /// Typically implemented using SVG polyline or path.
    /// </summary>
    /// <param name="points">List of points defining the curve.</param>
    /// <param name="strokeColor">Stroke color of the curve.</param>
    /// <param name="strokeWidth">Stroke width of the curve.</param>
    /// <returns>The current SvgDocument for chaining.</returns>
    public SvgDocument AddCurvedLine(List<(int, int)> points, Color strokeColor, int strokeWidth)
    {
        Shapes.Add(new CurvedLine(points, strokeColor, strokeWidth));
        return this;
    }

    /// <summary>
    /// Adds text to the SVG document.
    /// </summary>
    /// <param name="content">Text content.</param>
    /// <param name="centrum">Position of the text (x, y).</param>
    /// <param name="fontSize">Font size.</param>
    /// <param name="fontFamily">Font family name.</param>
    /// <param name="fillColor">Text fill color (optional).</param>
    /// <param name="strokeColor">Text stroke color (optional).</param>
    /// <param name="strokeWidth">Stroke width (optional).</param>
    /// <returns>The current SvgDocument for chaining.</returns>
    public SvgDocument AddText(string content, (int x, int y) centrum, int fontSize, string fontFamily, Color? fillColor,
        Color? strokeColor, int? strokeWidth)
    {
        Shapes.Add(new Text(content, centrum, fontSize, fontFamily, fillColor, strokeColor, strokeWidth));
        return this;
    }

    /// <summary>
    /// Generates the SVG string representing this document and all shapes.
    /// </summary>
    /// <returns>A complete SVG string.</returns>
    public override string ToString()
    {
        return GenerateSVGString(Shapes);
    }

    /// <summary>
    /// Helper method to generate the full SVG XML string from the list of shapes.
    /// </summary>
    /// <param name="shapes">List of shapes to include in the SVG.</param>
    /// <returns>SVG as string.</returns>
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
