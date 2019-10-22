using System.Collections.Generic;

namespace Builder
{
    public class Mail
    {
        public string To { get; }
        public string[] CopyTo { get; }
        public string Subject { get; }
        public string Body { get; }

        public Mail(string to, string[] copyTo, string subject, string body)
        {
            To = to;
            CopyTo = copyTo;
            Subject = subject;
            Body = body;
        }
    }

    public class MailBuilder
    {
        private readonly string to;
        private readonly string body;
        private string subject = string.Empty;
        private readonly List<string> copyTo = new List<string>();

        public MailBuilder(string to, string body)
        {
            this.to = to;
            this.body = body;
        }

        public MailBuilder AddCopyTo(string receiver)
        {
            copyTo.Add(receiver);
            return this;
        }

        public MailBuilder SetSubject(string newSubject)
        {
            subject = newSubject;
            return this;
        }

        public Mail Build()
        {
            return new Mail(to, copyTo.ToArray(), subject, body);
        }
    }
}
