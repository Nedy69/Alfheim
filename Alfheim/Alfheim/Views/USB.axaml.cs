using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Alfheim.Views;

public partial class USB : UserControl
{
    public USB()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}