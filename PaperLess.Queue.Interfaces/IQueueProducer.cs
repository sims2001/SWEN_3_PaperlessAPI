namespace PaperLess.Queue.Interfaces {

    public interface IQueueProducer {
        void PublishToQueue(string body);
    }

}