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
}