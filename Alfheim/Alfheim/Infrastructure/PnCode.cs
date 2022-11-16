using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Alfheim.Infrastructure;

public class PnCode : INotifyPropertyChanged
{
    private Type _moveType;
    private double _x;
    private double _y;
    private double _z;
    private double _feed;

    public Type MoveType
    {
        get => _moveType;
        set => SetField(ref _moveType, value);
    }

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

    public double Feed
    {
        get => _feed;
        set => SetField(ref _feed, value);
    }

    public enum Type
    {
        Linear,
        Rapid
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}