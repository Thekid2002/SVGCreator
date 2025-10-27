# SVGCreator

`SVGCreator` is a lightweight C# library for creating SVG documents programmatically. It allows you to define shapes, lines, curves, and text with a fluent API, then export the complete SVG as a string.

## Features

- Create SVG documents of any width and height.
- Add **circles**, **lines**, **curved lines**, and **text**.
- Fluent interface for chaining multiple operations.
- XML documentation inherited from the interface for clean IntelliSense support.
- Easily extendable with new shapes.

## Github
https://github.com/Thekid2002/SVGCreator

## Usage

```csharp
using System.Drawing;
using SVGCreator;

class Program
{
    static void Main()
    {
        ISvgDocument svg = new SvgDocument()
            .SetWidth(500)
            .SetHeight(500)
            .AddCircle((250, 250), 100, Color.Red, Color.Black, 2)
            .AddLine((50, 50), (450, 450), Color.Blue, 3)
            .AddCurvedLine(new List<(int, int)>
            {
                (50, 250),
                (150, 350),
                (250, 250),
                (350, 150),
                (450, 250)
            }, Color.Green, 2)
            .AddText("Hello SVG", (200, 100), 24, "Arial", Color.Black, null, null);

        string svgContent = svg.ToString();

        // Save to file
        System.IO.File.WriteAllText("output.svg", svgContent);
    }
}
```

## API Overview

The main interface is `ISvgDocument`, which `SvgDocument` implements.


## Shape Methods

| Method                                                                                                                                                                                                | Description |
|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------|
| `AddCircle((int x, int y) center, int radius, Color? fillColor, Color? strokeColor, int? strokeWidth, string? additionalAttributesString = null)`                                                     | Adds a circle to the SVG document. |
| `AddLine((int x, int y) start, (int x, int y) end, Color strokeColor, int strokeWidth, string? additionalAttributesString = null)`                                                                    | Adds a straight line to the SVG document. |
| `AddCurvedLine(List<(int,int)> points, Color strokeColor, int strokeWidth, string? additionalAttributesString = null)`                                                                                | Adds a curved line defined by multiple points (polyline/path). |
| `AddText(string content, (int x, int y) centrum, int fontSize, string? fontFamily, int? rotation, Color? fillColor, Color? strokeColor, int? strokeWidth, string? additionalAttributesString = null)` | Adds text to the SVG document. |
| `AddSquare((int x, int y) center, int sideLength, Color? fillColor, Color? strokeColor, int? strokeWidth, string? additionalAttributesString = null)`                                                 | Adds a square to the SVG document. |
| `AddRectangle((int x, int y) center, int width, int height, Color? fillColor, Color? strokeColor, int? strokeWidth, string? additionalAttributesString = null)`                                       | Adds a rectangle to the SVG document. |

## Notes

- Colors use `System.Drawing.Color`. The library automatically converts them to SVG hex strings.
- Text and curved lines are positioned using top-left or point lists.
- The generated SVG can be saved directly to a `.svg` file and viewed in browsers or vector graphic editors.
