using NUnit.Framework;
using TestNinjaCore.Fundamentals;

namespace TestNinjaCore.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("abc");

            // Specific assertion
            // why? verifying the exact string
            // this is good.. want to make sure properly formatted
            Assert.That(result, Is.EqualTo("<strong>abc</strong>"));

            // More General
            // may not catch a bug
            // be default, case sensitivity is what happens
            // if don't care about case sensitivity use .IgnoreCase
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);

            // better to add this too
            Assert.That(result, Does.EndWith("</strong>"));

            Assert.That(result, Does.Contain("abc"));

            // with strings better if asserts are little more general
            // so tests don't break so easily

            // but what if returning an error message
            // you don't want to test that the specific message is returned
            // because you might change the wording later in the future
            // if test is that specific, every time change error message, test is going to break

            // shouldn't be too general, because they will pass all the time
        }
    }
}