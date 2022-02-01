using System;
using System.Windows;

namespace Chatter
{
    public partial class ChatWindow : Window, IObserver
    {
        private Subject subject;
        public string ClientName { get; }

        public string TopicsOfInterest => throw new System.NotImplementedException();

        public ChatWindow(Subject subject, string clientName)
        {
            InitializeComponent();
            ClientName = clientName;
            Title = $"ChatClient: {ClientName}";
            this.subject = subject;
            this.subject.Attach(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var msg = ChatTextBox.Text;
            if (msg.Length == 0) return;

            subject.Notify(new Message
            {
                Content = msg,
                Name = ClientName,
                Timestamp = DateTime.Now
            });
        }

        public void Update(Message message)
        {
            MessagesList.Items.Add(message.ToString());
        }

        public void ClientAttached(string name) { }
        public void ClientDetached(string name) { }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            subject.Detach(this);
        }
    }
}
