using System.Collections.Generic;

namespace Chatter
{
    public abstract class Subject
    {
        private readonly List<IObserver> observers = new();
        public int NrObservers { get; }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify(string name, string msg)
        {
            observers.ForEach(observer => observer.Update(name, msg));
        }
    }
}
