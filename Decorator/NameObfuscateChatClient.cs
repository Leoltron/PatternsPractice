using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Decorator
{
    public class NameObfuscateChatClient : IChatClient
    {
        private readonly IChatClient baseClient;

        public NameObfuscateChatClient(IChatClient baseClient)
        {
            this.baseClient = baseClient;
        }

        public void SendMessage(Message message) => baseClient.SendMessage(message);

        public IEnumerable<Message> ReceiveMessages() => baseClient.ReceiveMessages().Select(ObfuscateSenderName).ToList();

        private static Message ObfuscateSenderName(Message m) =>
            new Message(ToHashString(m.Author).Substring(0, 7), m.Recipient, m.Text);

        private static string ToHashString(string s)
        {
            using (var hash = SHA256.Create())
            {
                return string.Concat(hash
                                    .ComputeHash(Encoding.UTF8.GetBytes(s))
                                    .Select(item => item.ToString("x2")));
            }
        }
    }
}
