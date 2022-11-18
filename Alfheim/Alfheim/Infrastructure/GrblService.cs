using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using Alfheim.Exceptions;
using ZenCNC.STEAM.grbl;

namespace Alfheim.Infrastructure;

public class GrblService : INotifyPropertyChanged
{
    private readonly GrblClient _grblClient;
    private readonly SerialPort _serial;
    private string[]? _ports;
    private Joints _current = new();
    private Joints _wanted = new();
    private Position _cartCurrent = new();
    private Position _cartWanted = new();

    public string[]? Ports
    {
        get => _ports;
        set => SetField(ref _ports, value);
    }

    public Joints Current
    {
        get => _current;
        set => SetField(ref _current, value);
    }

    public Joints Wanted
    {
        get => _wanted;
        set => SetField(ref _wanted, value);
    }

    //TODO: Compute using IK
    public Position CartCurrent
    {
        get => _cartCurrent;
        set => SetField(ref _cartCurrent, value);
    }

    public Position CartWanted
    {
        get => _cartWanted;
        set => SetField(ref _cartWanted, value);
    }

    public GrblService()
    {
        _grblClient = new GrblClient();
        _serial = new SerialPort();
    }

    public void ScanPorts()
    {
        Ports = SerialPort.GetPortNames();
    }

    public bool Connect(string port)
    {
        return _grblClient.Open(new PortDesc() { DeviceId = port });
    }

    public void MoveAll()
    {
        if (!_grblClient.IsConnected) throw new NotConnectedException();
        _grblClient.Send($"G0X{_wanted.Q1}Y{_wanted.Q2}Z{_wanted.Q3}A{_wanted.Q4}B{_wanted.Q5}C{_wanted.Q6}");
        _current = _wanted;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

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