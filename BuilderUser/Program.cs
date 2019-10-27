using Builder;

namespace BuilderUser
{
    public static class Program
    {
        public static void Main()
        {
            var builder = new MailBuilder().SetSubject("").SetTo(null).SetBody(null).Build();
        }
    }
}
