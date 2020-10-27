using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Pass() => Assert.Pass();

        [Test]
        public void Fail() => Assert.Fail();
    }
}