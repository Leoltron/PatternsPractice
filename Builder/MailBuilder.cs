using System;
using System.Collections.Generic;
using System.Linq;

namespace Builder
{
    public class MailBuilder
    {
        internal readonly string Subject = string.Empty;
        internal readonly IReadOnlyList<string> CopyTo;

        public MailBuilder()
        {
        }

        private MailBuilder(string subject, IEnumerable<string> copyTo)
        {
            Subject = subject;
            CopyTo = copyTo.ToList();
        }

        public MailBuilder AddCopyTo(string receiver) => new MailBuilder(Subject, CopyTo.Append(receiver));

        public MailBuilder SetSubject(string newSubject) => new MailBuilder(newSubject, CopyTo);

        public BodySetMailBuilder SetBody(string body) => new BodySetMailBuilder(body, this);

        public ToSetMailBuilder SetTo(string to) => new ToSetMailBuilder(to, this);
    }


    public class ToSetMailBuilder
    {
        private readonly string to;
        private readonly MailBuilder mailBuilder;

        internal ToSetMailBuilder(string to, MailBuilder mailBuilder)
        {
            this.to = to ?? string.Empty;
            this.mailBuilder = mailBuilder;
        }

        public ToSetMailBuilder AddCopyTo(string receiver) => new ToSetMailBuilder(to, mailBuilder.AddCopyTo(receiver));

        public ToSetMailBuilder SetSubject(string newSubject) =>
            new ToSetMailBuilder(to, mailBuilder.SetSubject(newSubject));

        public FinishedMailBuilder SetBody(string body) => new FinishedMailBuilder(to, body, mailBuilder);

        public ToSetMailBuilder SetTo(string newTo) => new ToSetMailBuilder(newTo, mailBuilder);
    }


    public class BodySetMailBuilder
    {
        private readonly string body;
        private readonly MailBuilder mailBuilder;

        internal BodySetMailBuilder(string body, MailBuilder mailBuilder)
        {
            this.body = body ?? string.Empty;
            this.mailBuilder = mailBuilder;
        }

        public BodySetMailBuilder AddCopyTo(string receiver) =>
            new BodySetMailBuilder(body, mailBuilder.AddCopyTo(receiver));

        public BodySetMailBuilder SetSubject(string newSubject) =>
            new BodySetMailBuilder(body, mailBuilder.SetSubject(newSubject));

        public BodySetMailBuilder SetBody(string newBody) => new BodySetMailBuilder(newBody, mailBuilder);
        public FinishedMailBuilder SetTo(string to) => new FinishedMailBuilder(to, body, mailBuilder);
    }

    public class FinishedMailBuilder
    {
        private readonly string to;
        private readonly string body;
        private readonly MailBuilder mailBuilder;

        internal FinishedMailBuilder(string to, string body, MailBuilder mailBuilder)
        {
            this.to = to ?? string.Empty;
            this.body = body ?? string.Empty;
            this.mailBuilder = mailBuilder;
        }

        public FinishedMailBuilder AddCopyTo(string receiver) =>
            new FinishedMailBuilder(to, body, mailBuilder.AddCopyTo(receiver));

        public FinishedMailBuilder SetSubject(string newSubject) =>
            new FinishedMailBuilder(to, body, mailBuilder.SetSubject(newSubject));

        public FinishedMailBuilder SetBody(string newBody) => new FinishedMailBuilder(to, newBody, mailBuilder);
        public FinishedMailBuilder SetTo(string newTo) => new FinishedMailBuilder(newTo, body, mailBuilder);

        public Mail Build()
        {
            return new Mail(to, mailBuilder.CopyTo.ToArray(), mailBuilder.Subject, body);
        }
    }
}
