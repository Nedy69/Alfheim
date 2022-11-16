using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Alfheim.Views;

public partial class ListBox : UserControl
{
    public ListBox()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}