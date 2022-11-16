using Alfheim.Controls;
using Avalonia.Markup.Xaml;

namespace Alfheim.Views;

public partial class Articulation : ArticulationControl
{
    public Articulation()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}