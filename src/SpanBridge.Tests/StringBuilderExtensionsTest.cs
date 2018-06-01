using System;
using System.Runtime.InteropServices;
using System.Text;
using NUnit.Framework;

namespace SpanBridge.Tests
{
    [TestFixture]
    public class StringBuilderExtensionsTest
    {
        [Test]
        public void CanAppendToStringBuilder()
        {
            var sb = new StringBuilder();
            sb.Append("Hello World".AsSpan());
            Assert.That(sb.ToString(), Is.EqualTo("Hello World"));
        }

        [Test]
        public void CanInsertToStringBuilder()
        {
            var sb = new StringBuilder("World");
            sb.Insert(0, "Hello ".AsSpan());
            Assert.That(sb.ToString(), Is.EqualTo("Hello World"));
        }

        [Test]
        public void CheckEquals()
        {
            var sb = new StringBuilder("Hello World");
            var equals = sb.Equals("Hello World".AsSpan());
            Assert.That(equals);
        }
        
        [Test]
        public void CheckNotEquals()
        {
            var sb = new StringBuilder("Hello World!");
            var equals = sb.Equals("Hello World1".AsSpan());
            Assert.That(equals, Is.Not.True);
        }
    }
}