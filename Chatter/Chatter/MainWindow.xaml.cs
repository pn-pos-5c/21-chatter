using System;
using System.Windows;

namespace Chatter
{
    public partial class MainWindow : Window, IObserver
    {
        private Subject subject = new Subject();
        public string ClientName => "Server";
        public string TopicsOfInterest => throw new NotImplementedException();

        public MainWindow()
        {
            InitializeComponent();
            subject.Attach(this);
        }

        public void ClientAttached(string name)
        {
            UpdateClientCount(subject.NrObservers - 1);
            ClientLogList.Items.Add($"[{DateTime.Now.ToLongTimeString()}] {name}: attached");
        }
        public void ClientDetached(string name)
        {
            UpdateClientCount(subject.NrObservers - 1);
            ClientLogList.Items.Add($"[{DateTime.Now.ToLongTimeString()}] {name}: detached");
        }
        public void Update(Message message)
        {
            MessagesList.Items.Add(message.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var name = ClientNameText.Text;
            if (name.Length == 0) return;

            new ChatWindow(subject, name).Show();
        }

        private void UpdateClientCount(int count)
        {
            NrClientLabel.Content = $"Nr Clients    {count}";
        }
    }
}
