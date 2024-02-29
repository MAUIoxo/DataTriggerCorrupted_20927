namespace DataTriggerCorruptedExample.Pages.Views;

public partial class StoreSelectionItemView : ContentView
{
	public StoreSelectionItemView()
	{
		InitializeComponent();
	}

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;

        int input = 0;

        if (!string.IsNullOrEmpty(e.NewTextValue) && !int.TryParse(e.NewTextValue, out input) || e.NewTextValue == null || e.NewTextValue.Length > 1 && e.NewTextValue.StartsWith("0") || input < 0)
        {
            entry.Text = e.OldTextValue;
        }

        entry.CursorPosition = e.NewTextValue == null ? 0 : e.NewTextValue.Length;
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
}