namespace Chatter
{
    public interface IObserver
    {
        public string ClientName { get; }
        public string TopicsOfInterest { get; }

        public void Update(Message message);
        public void ClientAttached(string name);
        public void ClientDetached(string name);
    }
}
