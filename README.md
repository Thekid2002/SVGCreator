# SVGCreator

`SVGCreator` is a lightweight C# library for creating SVG documents programmatically. It allows you to define shapes, lines, curves, and text with a fluent API, then export the complete SVG as a string.

## Features

- Create SVG documents of any width and height.
- Add **circles**, **lines**, **curved lines**, and **text**.
- Fluent interface for chaining multiple operations.
- XML documentation inherited from the interface for clean IntelliSense support.
- Easily extendable with new shapes.

## Installation

Clone the repository or add the source files directly to your project:

```bash
git clone https://github.com/yourusername/SVGCreator.git
```

Add references to:

```csharp
using System.Drawing;
using SVGCreator;
```

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

### Methods

| Method | Description |
|--------|-------------|
| `SetWidth(int width)` | Set the width of the SVG canvas. |
| `SetHeight(int height)` | Set the height of the SVG canvas. |
| `AddCircle((int x, int y) center, int radius, Color? fillColor, Color? strokeColor, int? strokeWidth)` | Add a circle to the document. |
| `AddLine((int x, int y) start, (int x, int y) end, Color strokeColor, int strokeWidth)` | Add a straight line. |
| `AddCurvedLine(List<(int,int)> points, Color strokeColor, int strokeWidth)` | Add a curved line connecting multiple points. |
| `AddText(string content, (int x, int y) topLeft, int fontSize, string fontFamily, Color? fillColor, Color? strokeColor, int? strokeWidth)` | Add text to the document. |
| `ToString()` | Generate the complete SVG string. |

## Notes

- Colors use `System.Drawing.Color`. The library automatically converts them to SVG hex strings.
- Text and curved lines are positioned using top-left or point lists.
- The generated SVG can be saved directly to a `.svg` file and viewed in browsers or vector graphic editors.
