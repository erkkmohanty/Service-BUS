using Microsoft.Azure.ServiceBus;
using System;
using System.Text;

namespace Master
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Endpoint=sb://kirantest.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=dgcGBxkKOMYWOSZY1U+xPLotGsqIZ9UpnkZLK/Ct+VM=";

            var queueClient = new QueueClient(connectionString, "myqueue");
            var numberOfMessagesToSend = 100;
            //Sending a message
            try
            {
                for (var i = 0; i < numberOfMessagesToSend; i++)
                {
                    // Create a new message to send to the queue
                    string messageBody = $"Message {i}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                    // Write the body of the message to the console
                    Console.WriteLine($"Sending message: {messageBody}");

                    // Send the message to the queue
                     queueClient.SendAsync(message);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
            Console.WriteLine("Message(s) sent.");


            Console.WriteLine("Done, press a key to continue...");
            Console.ReadKey();

            
        }
    }
}
