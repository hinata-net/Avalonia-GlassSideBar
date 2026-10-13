using Avalonia.Controls;
using System;
using System.Linq;

namespace GlassSideBar.Demo.Pages;

public partial class ProjectsPage : UserControl
{
    private readonly Border[] _projectCards = [];

    public ProjectsPage()
    {
        InitializeComponent();

        _projectCards =
        [
            AtlasCard,
            NorthstarCard,
            BrandCard,
            PortalCard
        ];
        ApplyFilters();
    }

    private void ApplyFilters()
    {
        if (ProjectSearchBox is null ||
        StatusFilterComboBox is null ||
        ProjectCountText is null ||
        EmptyState is null ||
        _projectCards.Length == 0)
        {
            return;
        }

        string query = ProjectSearchBox.Text?.Trim() ?? string.Empty;
        string? selectedFilter = (StatusFilterComboBox.SelectedItem as ComboBoxItem)?
            .Content?.ToString();

        int visibleCount = 0;

        foreach (Border card in _projectCards)
        {
            string[] metadata = card.Tag?.ToString()?.Split('|', 2) ?? [];
            string status = metadata.ElementAtOrDefault(0) ?? string.Empty;
            string searchableText = metadata.ElementAtOrDefault(1) ?? string.Empty;

            bool matchesStatus =
                string.IsNullOrEmpty(selectedFilter) ||
                selectedFilter == "All projects" ||
                status.Equals(selectedFilter, StringComparison.OrdinalIgnoreCase);

            bool matchesSearch =
                string.IsNullOrEmpty(query) ||
                searchableText.Contains(query, StringComparison.OrdinalIgnoreCase);

            card.IsVisible = matchesStatus && matchesSearch;

            if (card.IsVisible)
                visibleCount++;
        }

        ProjectCountText.Text = $"{visibleCount} project{(visibleCount == 1 ? "" : "s")}";
        EmptyState.IsVisible = visibleCount == 0;
    }

    private void OnStatusSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        ApplyFilters();
    }

    private void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
    {
        ApplyFilters();
    }
}