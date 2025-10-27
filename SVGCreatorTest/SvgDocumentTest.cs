using SVGCreator;

namespace SVGCreatorTest;

public class SvgDocumentTest
{
    [Fact]
    public void Test1()
    {
        var document = new SvgDocument().SetWidth(100)
            .SetHeight(100)
            .AddCircle((50, 50), 40, System.Drawing.Color.Red, System.Drawing.Color.Black, 2)
            .ToString();
        
        var expected = @"<svg width=""100"" height=""100"" xmlns=""http://www.w3.org/2000/svg"">
            <circle cx=""50"" cy=""50"" r=""40"" stroke=""Black"" stroke-width=""2"" fill=""Red""/>
        </svg>";
        Assert.Equal(expected.Replace(" ", "").Replace("\n", ""), document.Replace(" ", "").Replace("\n", ""));
    }

    [Fact]
    public void Test2()
    {
        var document = new SvgDocument()
            .SetWidth(200)
            .SetHeight(200)
            .AddRectangle((100, 100), 80, 40, System.Drawing.Color.Blue, System.Drawing.Color.Green, 3)
            .AddSquare((50, 50), 30, System.Drawing.Color.Yellow, System.Drawing.Color.Purple, 1)
            .ToString();
        
        var expected = @"<svg width=""200"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
            <rect x=""60"" y=""80"" width=""80"" height=""40"" stroke=""Green"" stroke-width=""3"" fill=""Blue""/>
            <rect x=""35"" y=""35"" width=""30"" height=""30"" stroke=""Purple"" stroke-width=""1"" fill=""Yellow""/>
            </svg>";
        Assert.Equal(expected.Replace(" ", "").Replace("\n", ""), document.Replace(" ", "").Replace("\n", ""));
    }
}