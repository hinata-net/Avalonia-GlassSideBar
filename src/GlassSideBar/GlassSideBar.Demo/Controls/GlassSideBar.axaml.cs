using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;

namespace GlassSideBar.Demo.Controls;

public partial class GlassSideBar : UserControl
{
    public static readonly StyledProperty<IEnumerable<MenuItemData>?> MenuContentProperty =
        AvaloniaProperty.Register<GlassSideBar, IEnumerable<MenuItemData>?>(nameof(MenuContent));

    public IEnumerable<MenuItemData>? MenuContent
    {
        get => GetValue(MenuContentProperty);
        set => SetValue(MenuContentProperty, value);
    }

    public GlassSideBar()
    {
        InitializeComponent();

        PageContent.AddHandler(PointerPressedEvent, (_, _) => RootSplitView.IsPaneOpen = false, RoutingStrategies.Tunnel);
    }
}