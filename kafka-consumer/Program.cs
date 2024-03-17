namespace kafka_consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!, This is Kafka Consumer Application");
            
            ConsumeMessage consumeMessage = new ConsumeMessage();
            consumeMessage.ReadMessage();
        }
    }
}