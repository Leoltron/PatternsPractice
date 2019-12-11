using System.Collections.Generic;
using System.Linq;

namespace Decorator
{
    public class EncryptChatClient : IChatClient
    {
        private const string StartTag = "<encrypted>";
        private const string EndTag = "</encrypted>";
        private readonly IChatClient baseClient;

        public EncryptChatClient(IChatClient baseClient)
        {
            this.baseClient = baseClient;
        }

        public void SendMessage(Message message) => baseClient.SendMessage(EncryptMessage(message));

        private static Message EncryptMessage(Message message) =>
            new Message(message.Author, message.Recipient, Encrypt(message.Text));

        private static string Encrypt(string s) => $"{StartTag}{s}{EndTag}";

        public IEnumerable<Message> ReceiveMessages() => baseClient.ReceiveMessages()
                                                                   .Select(DecryptMessage)
                                                                   .ToList();

        private static Message DecryptMessage(Message message) =>
            new Message(message.Author, message.Recipient, Decrypt(message.Text));

        private static string Decrypt(string s) =>
            s.Substring(StartTag.Length, s.Length - StartTag.Length - EndTag.Length);
    }
}
