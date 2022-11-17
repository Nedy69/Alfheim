using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Alfheim.Infrastructure;

namespace Alfheim.ViewModels;

public class ScriptingViewModel : ViewModelBase
{
    public ObservableCollection<PnCode> PnCodes { get; } = new();
    public double Height { get; set; } = 50;

    public ScriptingViewModel()
    {
        for (var i = 0; i < 20; i++)
        {
            PnCodes.Add(new PnCode { MoveType = PnCode.Type.Linear, Feed = 100, X = i*10, Y = i*10, Z = i*10});
            PnCodes.Add(new PnCode { MoveType = PnCode.Type.Rapid, Feed = 100, X = i*10, Y = i*10, Z = i*10});
        }
    }
}