using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Alfheim.Views;

public partial class Gripper : UserControl
{
    public Gripper()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}