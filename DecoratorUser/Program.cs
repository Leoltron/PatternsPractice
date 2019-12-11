using System;
using System.Collections.Generic;
using System.Linq;
using Decorator;

namespace DecoratorUser
{
    internal static class Program
    {
        private static readonly ChatServer Server = new ChatServer();
        private static List<IChatClient> clients;

        public static void Main()
        {
            var clientA = new EncryptChatClient(NewClient("A"));
            var clientB = new EncryptChatClient(NewClient("B"));

            var clientC = new NameObfuscateChatClient(NewClient("C"));
            var clientD = NewClient("D");
            clients = new List<IChatClient>
            {
                clientA,
                clientB,
                clientC,
                clientD
            };

            clientA.SendMessage(new Message("A", "B", "Hello, B!"));
            clientB.SendMessage(new Message("B", "A", "Hello, A!"));

            clientA.SendMessage(new Message("A", "C", "Hello, C!"));
            clientB.SendMessage(new Message("B", "C", "Hello, C!"));
            clientD.SendMessage(new Message("D", "C", "Hello, C!"));

            ReceiveAndPrintAllMessages();
        }

        private static void ReceiveAndPrintAllMessages()
        {
            foreach (var message in clients.SelectMany(c => c.ReceiveMessages()))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

        private static ChatClient NewClient(string name)
        {
            return new ChatClient(Server, name);
        }
    }
}
