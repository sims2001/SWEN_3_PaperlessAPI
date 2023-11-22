namespace PaperLess.Queue.Interfaces {

    public interface IQueueConsumer {
        event EventHandler<QueueReceivedEventArgs> OnReceived;
        void StartReceive();
        void StopReceive();

    }
}