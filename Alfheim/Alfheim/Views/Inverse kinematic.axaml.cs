using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Alfheim.Views;

public partial class InverseKinematic : UserControl
{
    public InverseKinematic()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}