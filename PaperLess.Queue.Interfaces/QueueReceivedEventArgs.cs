namespace PaperLess.Queue.Interfaces {

    public class QueueReceivedEventArgs {
        public QueueReceivedEventArgs(string content) {
            Content = content;
        }

        public string Content { get; }

    }

}