using NUnit.Framework;
using TestNinjaCore.Fundamentals;

namespace TestNinjaCore.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [Test]
        public void Count_WhenAccessed_ReturnNumberOfItemsInStack()
        { 
            _stack.Push("test");

            var count = _stack.Count;

            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void Push_WhenCalledWithNull_ThrowsArgumentNullException()
        { 
            Assert.That(() => _stack.Push(null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void Push_WhenCalled_ShouldAddItemToStack()
        { 
            _stack.Push("test");

            var count = _stack.Count;

            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_WhenCalledWithNoItems_ThrowsInvalidOperationException()
        { 
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_WhenCalled_ShouldReturnLastItemInStackAndRemoveIt()
        { 
            _stack.Push("test");
            var item = _stack.Pop();

            Assert.That(item, Is.EqualTo("test"));
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Peek_WhenCalledWithNoItems_ThrowsInvalidOperationException()
        { 
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_WhenCalled_ShouldReturnLastItemInStackWithoutRemoving()
        { 
            _stack.Push("test");
            var item = _stack.Peek();

            Assert.That(item, Is.EqualTo("test"));
            Assert.That(_stack.Count, Is.EqualTo(1));
        }
    }
}