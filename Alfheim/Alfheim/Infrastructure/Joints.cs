using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Alfheim.Infrastructure;

public class Joints : INotifyPropertyChanged
{
    private double _q1;
    private double _q2;
    private double _q3;
    private double _q4;
    private double _q5;
    private double _q6;
    private double _gripper;
    public event PropertyChangedEventHandler? PropertyChanged;

    public double Q1
    {
        get => _q1;
        set => SetField(ref _q1, value);
    }

    public double Q2
    {
        get => _q2;
        set => SetField(ref _q2, value);
    }

    public double Q3
    {
        get => _q3;
        set => SetField(ref _q3, value);
    }

    public double Q4
    {
        get => _q4;
        set => SetField(ref _q4, value);
    }

    public double Q5
    {
        get => _q5;
        set => SetField(ref _q5, value);
    }

    public double Q6
    {
        get => _q6;
        set => SetField(ref _q6, value);
    }

    public double Gripper
    {
        get => _gripper;
        set => SetField(ref _gripper, value);
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