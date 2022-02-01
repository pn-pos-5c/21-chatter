using System.Collections.Generic;

namespace Chatter
{
    public class Subject
    {
        private readonly List<IObserver> observers = new();
        public int NrObservers { get => observers.Count; }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
            foreach (var o in observers)
            {
                o.ClientAttached(observer.ClientName);
            }
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
            foreach (var o in observers)
            {
                o.ClientDetached(observer.ClientName);
            }
        }

        public void Notify(Message message)
        {
            observers.ForEach(observer => observer.Update(message));
        }
    }
}
