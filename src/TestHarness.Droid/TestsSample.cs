using System;

using NUnit.Framework;

namespace TestHarness.Droid
{
    [TestFixture]
    public class TestsSample
    {
        [Test]
        public void Fail()
        {
            Assert.False (true);
        }

        [Test]
        [Ignore("another time")]
        public void Ignore()
        {
            Assert.True (false);
        }

        [Test]
        public void Inconclusive()
        {
            Assert.Inconclusive ("Inconclusive");
        }

        [Test]
        public void Pass()
        {
            Console.WriteLine ("test1");
            Assert.True (true);
        }

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void Tear()
        {
        }
    }
}