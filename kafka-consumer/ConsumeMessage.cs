﻿using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kafka_consumer
{
    internal class ConsumeMessage
    {
        public void ReadMessage()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = Environment.GetEnvironmentVariable("KAFKA_CONNECTION"),// "kafka-1:19092",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                ClientId = "my-app",
                GroupId = "my-group",
                BrokerAddressFamily = BrokerAddressFamily.V4,
            };

            using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

            consumer.Subscribe("kafka.learning.orders");

            try
            {
                while (true)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));

                    var consumeResult = consumer.Consume();
                    Console.WriteLine($"Message received from {consumeResult.TopicPartitionOffset}: {consumeResult.Message.Value}");
                }
            }
            catch (OperationCanceledException)
            {
                // The consumer was stopped via cancellation token.
            }
            finally
            {
                consumer.Close();
            }

            Console.ReadLine();

        }
    }
}
