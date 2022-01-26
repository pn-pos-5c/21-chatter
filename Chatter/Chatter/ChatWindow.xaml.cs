using System.Windows;

namespace Chatter
{
    public partial class ChatWindow : Window
    {
        private string name = string.Empty;
        public string Name { get; set; }

        public ChatWindow()
        {
            InitializeComponent();
        }
    }
}
