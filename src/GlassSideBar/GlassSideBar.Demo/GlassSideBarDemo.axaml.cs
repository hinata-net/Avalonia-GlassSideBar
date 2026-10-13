using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using GlassSideBar.Demo.Controls;
using GlassSideBar.Demo.Pages;
using System;
using System.Collections.Generic;

namespace GlassSideBar.Demo;

public partial class GlassSideBarDemo : UserControl
{
    public GlassSideBarDemo()
    {
        InitializeComponent();

        Items =
        [
            new("Dashboard", GetIcon("DashboardIcon"), new DashboardPage()),
            new("Projects", GetIcon("ProjectsIcon"), new ProjectsPage()),
            new("Settings", GetIcon("SettingsIcon"), new SettingsPage())
        ];
        DataContext = this;
    }

    public List<MenuItemData> Items { get; }

    private Geometry GetIcon(string key)
    {
        if (Application.Current!.TryGetResource(key, ActualThemeVariant, out object? value) && value is Geometry geometry)
            return geometry;

        throw new InvalidOperationException($"Icon resource not found: '{key}'.");
    }
}