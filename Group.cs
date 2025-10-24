namespace SVGCreator;

public class Group : Shape
{
    public string Name { get; set; }

    private List<Shape> ShapesOrGroups { get; set; }

    public Point Origin { get; set; }

    public void AddShape(Shape shape)
    {
        ShapesOrGroups.Add(shape);
    }

    public void AddShapeRange(List<Shape> shapes)
    {
        ShapesOrGroups.AddRange(shapes);
    }

    public void AddGroup(Group group)
    {
        ShapesOrGroups.Add(group);
    }

    public void AddGroupRange(List<Group> groups)
    {
        ShapesOrGroups.AddRange(groups);
    }

    public Group(string name, Point origin)
    {
        this.ShapesOrGroups = new List<Shape>();
        this.Origin = origin;
        this.Name = name;
    }

    public string ToSvgString(Point origin)
    {
        origin.X += this.Origin.X;
        origin.Y += this.Origin.Y;
        string content = "\n<g id='" + this.Name + "'>\n";
        foreach (var shape in this.ShapesOrGroups)
        {
            content += "    " + shape.ToSvgString(origin) + "\n";
        }
        content += "</g>\n";
        return content;
    }
}
