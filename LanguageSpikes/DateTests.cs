﻿using System;
using NUnit.Framework;

namespace LanguageSpikes
{
    public class DateTests
    {
        [Test]
        public void ShouldHaveNowLocalDateKind()
        {
            Assert.That(DateTime.Now.Kind, Is.EqualTo(DateTimeKind.Local));
        }

        [Test]
        public void ShouldHaveLocalDateKind()
        {
            var d = new DateTime(2014, 1, 1).ToLocalTime();
            Assert.That(d.Kind, Is.EqualTo(DateTimeKind.Local));
        }

        [Test]
        public void ShouldHaveUnspecifiedDateKind()
        {
            var d = new DateTime(2014, 1, 1);
            Assert.That(d.Kind, Is.EqualTo(DateTimeKind.Unspecified));
        }

        [Test]
        public void ShouldReturnFalseWhenComparingUnspecifiedAndLocalDates()
        {
            var dUnspecified = new DateTime(2014, 1, 1);
            var dLocal = dUnspecified.ToLocalTime();

            Assert.That(dUnspecified, Is.Not.EqualTo(dLocal));
        }

        [Test]
        public void ShouldHaveUtcDateKind()
        {
            Assert.That(DateTime.UtcNow.Kind, Is.EqualTo(DateTimeKind.Utc));
        }

        [Test]
        public void ShouldReturnTrueWhenTwoDatesHaveSameTicksButAreDifferentKinds()
        {
            var d1 = new DateTime(100000L, DateTimeKind.Local);
            var d2 = new DateTime(100000L, DateTimeKind.Utc);

            Assert.That(d1.Kind, Is.Not.EqualTo(d2.Kind));
            Assert.That(d1, Is.EqualTo(d2));
        }

        [Test]
        public void ShouldCreateUtcDateThatIsUnspecifiedToRealUtc()
        {
            var dUnspecified = new DateTime(2014, 1, 1);
            var dUtc = DateTime.SpecifyKind(dUnspecified, DateTimeKind.Utc);

            Assert.That(dUtc.Kind, Is.EqualTo(DateTimeKind.Utc));
            Assert.That(dUtc, Is.EqualTo(dUnspecified));
        }
    }
}