using System;
using System.Collections.Generic;

namespace Alfheim.Infrastructure;

public class ObservableClass : IObservable<bool>
{
    private List<IObserver<bool>> _observers;

    public ObservableClass() => _observers = new List<IObserver<bool>>();

    public IDisposable Subscribe(IObserver<bool> observer)
    {
        if (! _observers.Contains(observer))
            _observers.Add(observer);
        return new Unsubscriber(_observers, observer);
    }

    private class Unsubscriber : IDisposable
    {
        private List<IObserver<bool>>_observers;
        private IObserver<bool> _observer;

        public Unsubscriber(List<IObserver<bool>> observers, IObserver<bool> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}