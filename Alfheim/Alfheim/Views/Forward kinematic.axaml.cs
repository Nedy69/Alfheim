using System;
using Alfheim.ViewModels;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Markup.Xaml;
using Splat;

namespace Alfheim.Views;

public partial class ForwardKinematic : UserControl, IEnableLogger
{
    public ForwardKinematic()
    {
        InitializeComponent();
        DataContext = new ArmViewModel();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}