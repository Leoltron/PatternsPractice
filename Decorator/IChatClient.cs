using System.Collections.Generic;

namespace Decorator
{
    public interface IChatClient
    {
        void SendMessage(Message message);
        IEnumerable<Message> ReceiveMessages();
    }
}
