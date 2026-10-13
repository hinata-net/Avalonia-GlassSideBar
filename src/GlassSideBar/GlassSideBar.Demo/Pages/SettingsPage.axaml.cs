using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;

namespace GlassSideBar.Demo.Pages;

public partial class SettingsPage : UserControl
{
    private readonly bool _isInitializing = true;

    public SettingsPage()
    {
        InitializeComponent();

        ThemeVariant? theme = Application.Current?.RequestedThemeVariant;

        ThemeComboBox.SelectedIndex =
            Equals(theme, ThemeVariant.Dark) ? 0 :
            Equals(theme, ThemeVariant.Light) ? 1 : 2;

        _isInitializing = false;
    }

    private void OnThemeSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (_isInitializing || Application.Current is not { } app)
            return;

        app.RequestedThemeVariant = ThemeComboBox.SelectedIndex switch
        {
            0 => ThemeVariant.Dark,
            1 => ThemeVariant.Light,
            _ => ThemeVariant.Default
        };
    }
}