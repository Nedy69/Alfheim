using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Alfheim.Views;

public partial class List : Window
{
    public List()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}