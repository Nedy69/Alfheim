using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Splat;

namespace Alfheim.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Locator.CurrentMutable.Register(() => new WindowNotificationManager(this));
            InitializeComponent();
        }
    }
}