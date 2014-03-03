using System;
using NUnit.Framework;

namespace LanguageSpikes
{
    public class DateTests
    {
        [Test]
        public void ShouldDoSomething()
        {
            var now = new DateTime(2014, 3, 3, 0, 0, 0);
            Print(now);
            Print(now.ToLocalTime());

            var nowUtc = new DateTime(2014, 3, 3, 0, 0, 0, DateTimeKind.Utc);
            Print(nowUtc);
            Print(nowUtc.ToLocalTime());
        }

        static void Print(DateTime dateTime)
        {
            Console.WriteLine("Kind: {0}, ToString: {1}", dateTime.Kind, dateTime);
        }
        }
}