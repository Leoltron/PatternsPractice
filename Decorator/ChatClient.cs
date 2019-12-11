using System;
using System.Collections.Generic;
using System.Linq;

namespace Decorator
{
    public class ChatClient : IChatClient
    {
        private readonly ChatServer server;
        private readonly string name;

        public ChatClient(ChatServer server, string name)
        {
            this.server = server;
            this.name = name;
        }

        public void SendMessage(Message message)
        {
            Console.WriteLine(
                $"[{name}] Sending message \"{message.Text}\" from {message.Author} to {message.Recipient}");
            server.Send(message);
        }

        public IEnumerable<Message> ReceiveMessages()
        {
            var messages = server.RetrieveMessages(name).ToList();
            messages.ForEach(m => Console.WriteLine($"[{name}] Received message from {m.Author}: \"{m.Text}\""));
            return messages;
        }
    }
}
