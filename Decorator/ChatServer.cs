using System.Collections.Generic;
using System.Linq;

namespace Decorator
{
    public class ChatServer
    {
        private readonly Dictionary<string, List<Message>> messageInbox = new Dictionary<string, List<Message>>();

        public void Send(Message message)
        {
            if (!messageInbox.TryGetValue(message.Recipient, out var messages))
            {
                messageInbox[message.Recipient] = messages = new List<Message>();
            }

            messages.Add(message);
        }

        public IEnumerable<Message> RetrieveMessages(string clientName)
        {
            if (!messageInbox.TryGetValue(clientName, out var inbox)) return Enumerable.Empty<Message>();
            var messages = inbox.ToList();
            inbox.Clear();
            return messages;
        }
    }
}
