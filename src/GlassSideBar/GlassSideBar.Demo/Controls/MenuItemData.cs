using Avalonia.Media;

namespace GlassSideBar.Demo.Controls;

public record class MenuItemData
{
    public string Label { get; }
    public Geometry Icon { get; }
    public object Content { get; }

    public MenuItemData(string label, Geometry icon, object content)
    {
        Label = label;
        Icon = icon;
        Content = content;
    }
}
