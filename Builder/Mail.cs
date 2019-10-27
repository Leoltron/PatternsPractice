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
}
