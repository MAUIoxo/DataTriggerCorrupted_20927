using CommunityToolkit.Maui.Core.Platform;

namespace DataTriggerCorruptedExample.Pages.Views;

public partial class TabView1 : ContentView
{
    public TabView1()
	{
		InitializeComponent();
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;

        int input = 0;

        if (!string.IsNullOrEmpty(e.NewTextValue) && !int.TryParse(e.NewTextValue, out input) || e.NewTextValue.Length > 1 && e.NewTextValue.StartsWith("0") || input < 0)
        {
            entry.Text = e.OldTextValue;
        }

        entry.CursorPosition = e.NewTextValue.Length;
    }

    private void Entry_Focused(object sender, FocusEventArgs e)
    {
        Dispatcher.Dispatch(() =>
        {
            var entry = sender as Entry;

            entry.CursorPosition = 0;
            entry.SelectionLength = entry.Text == null ? 0 : entry.Text.Length;
        });
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        foreach (Entry entry in this.Content.GetVisualTreeDescendants().Where(x => x is Entry))
        {
            if (KeyboardExtensions.IsSoftKeyboardShowing(entry))
            {
                KeyboardExtensions.HideKeyboardAsync(entry, default);
                break;
            }
        }
    }
}