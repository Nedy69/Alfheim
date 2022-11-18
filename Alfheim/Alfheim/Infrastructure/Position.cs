using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Alfheim.Infrastructure;

public class Position : INotifyPropertyChanged
{
    private double _x;
    private double _y;
    private double _z;
    private double _a;
    private double _b;
    private double _c;
    public event PropertyChangedEventHandler? PropertyChanged;

    public double X
    {
        get => _x;
        set => SetField(ref _x, value);
    }

    public double Y
    {
        get => _y;
        set => SetField(ref _y, value);
    }

    public double Z
    {
        get => _z;
        set => SetField(ref _z, value);
    }

    public double A
    {
        get => _a;
        set => SetField(ref _a, value);
    }

    public double B
    {
        get => _b;
        set => SetField(ref _b, value);
    }

    public double C
    {
        get => _c;
        set => SetField(ref _c, value);
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}