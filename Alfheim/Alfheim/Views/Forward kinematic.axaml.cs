using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Splat;

namespace Alfheim.Views;

public partial class ForwardKinematic : UserControl, IEnableLogger
{
    public ForwardKinematic()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}