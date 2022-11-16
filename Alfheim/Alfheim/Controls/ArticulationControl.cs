using System;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Metadata;

namespace Alfheim.Controls;

public class ArticulationControl: UserControl
{
    public static readonly DirectProperty<ArticulationControl,double> ValueProperty =
        AvaloniaProperty.RegisterDirect<ArticulationControl, double>(nameof(Value), articulation => articulation.Value,
            (articulation, v) => articulation.Value = v, defaultBindingMode: BindingMode.TwoWay,
            enableDataValidation: true);
    public static readonly DirectProperty<ArticulationControl,string> TextProperty =
        AvaloniaProperty.RegisterDirect<ArticulationControl, string>(nameof(Text), articulation => articulation.Text,
            (articulation, v) => articulation.Text = v, defaultBindingMode: BindingMode.TwoWay,
            enableDataValidation: true);
    private double _value;
    public double Value
    {
        get => _value;
        set => SetAndRaise(ValueProperty,ref _value, value);
    }
    private string _text;
    public string Text
    {
        get => _text;
        set => SetAndRaise(TextProperty,ref _text, value);
    }

    private void Plus(double value) => Value += value;

    [DependsOn(nameof(Value))]
    private bool Can(double value) => Value + value <= 100  && Value + value >= 0;
    public ICommand ClickPlus10 { get; set; }
    public ICommand ClickPlus1 { get; set; }
    public ICommand ClickPlus01 { get; set; }
    public ICommand ClickMinus10 { get; set; }
    public ICommand ClickMinus1 { get; set; }
    public ICommand ClickMinus01 { get; set; }

    protected ArticulationControl()
    {
        ClickPlus10 = new PlusCommand(_ => Can(10), _ =>Plus(10));
        ClickPlus1 = new PlusCommand( _=>Can(1),_=>Plus(1));
        ClickPlus01 = new PlusCommand( _=>Can(0.1),_=>Plus(0.1));
        ClickMinus10 = new PlusCommand( _=>Can(-10),_=>Plus(-10));
        ClickMinus1 = new PlusCommand( _=>Can(-1),_=>Plus(-1));
        ClickMinus01 = new PlusCommand( _=>Can(-0.1),_=>Plus(-0.1));
    }
}


public class PlusCommand : ICommand
{
    private readonly Predicate<object> _canExecute;
    private readonly Action<object> _execute;

    public PlusCommand(Predicate<object> canExecute, Action<object> execute)
    {
        _canExecute = canExecute;
        _execute = execute;
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CanExecuteChangeValue += value;
        remove => CanExecuteChangeValue -= value;
    }

    private event EventHandler? CanExecuteChangeValue;

    public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

    public void Execute(object parameter)
    {
        _execute.Invoke(parameter);
    }

    protected virtual void OnCanExecuteChangeValue()
    {
        CanExecuteChangeValue?.Invoke(this, EventArgs.Empty);
    }
}