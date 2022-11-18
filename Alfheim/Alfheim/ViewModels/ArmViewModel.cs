using System.Windows.Input;
using Alfheim.Infrastructure;
using Avalonia.Controls.Notifications;
using Avalonia.Threading;
using ReactiveUI;

namespace Alfheim.ViewModels;

public class ArmViewModel : ViewModelBase
{
    private readonly WindowNotificationManager? _manager;
    public ArmViewModel()
    {
        Service = Splat.Locator.Current.GetService(typeof(GrblService)) as GrblService;
        _manager = Splat.Locator.Current.GetService(typeof(WindowNotificationManager)) as WindowNotificationManager;
        GoAll = ReactiveCommand.Create(async () =>
        {
            try
            {
                Service?.MoveAll();
            }
            catch
            {
                //TODO: Display Warning
                /*await Dispatcher.UIThread.InvokeAsync(() =>
                    _manager?.Show(new Notification("Warning", "GRBL is disconnected", NotificationType.Warning)));*/
            }
        });
    }

    public GrblService? Service { get; }
    public ICommand GoAll { get; }
}