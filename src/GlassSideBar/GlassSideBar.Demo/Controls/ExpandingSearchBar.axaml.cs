using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Avalonia.VisualTree;
using System;

namespace GlassSideBar.Demo.Controls;

public partial class ExpandingSearchBar : UserControl
{
    public ExpandingSearchBar()
    {
        InitializeComponent();

        MainButton.AddHandler(PointerReleasedEvent, MainButton_OnPointerReleased, RoutingStrategies.Tunnel);
    }

    private void MainButton_OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        TextBox? textBox = MainButton.FindDescendantOfType<TextBox>();
        if (textBox == null) return;

        if (MainButton.IsChecked == true)
        {
            if (e.Source is Visual visual && (visual is TextBox || visual.FindAncestorOfType<TextBox>() != null))
                return;

            e.Handled = true;
            textBox.Focus();
        }
        else
        {
            TimeSpan delay = TryGetResource("ExpandDuration", ActualThemeVariant, out object? res) && res is TimeSpan duration
                ? duration
                : TimeSpan.FromMilliseconds(250);

            DispatcherTimer.RunOnce(() =>
            {
                if (MainButton.IsChecked == true)
                    textBox.Focus();
            }, delay);
        }
    }

    public static readonly StyledProperty<bool> IsExpandedProperty =
        AvaloniaProperty.Register<ExpandingSearchBar, bool>(nameof(IsExpanded));

    public bool IsExpanded
    {
        get => GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    private void MainButton_OnChecked(object? sender, RoutedEventArgs e)
    {
        TextBox? textBox = MainButton.FindDescendantOfType<TextBox>();
        if (textBox == null) return;

        if (MainButton.IsChecked == false)
        {
            textBox.Text = string.Empty;
        }
    }
}