namespace Chatter
{
    public interface IObserver
    {
        public string ClientName { get; set; }
        public string TopicsOfInterest { get; set; }

        public void Update(string name, string msg);
        public void ClientAttached(string name);
        public void ClientDetached(string name);
    }
}
