using NUnit.Framework;
using Word.W2004.Style;

namespace Test.W2004
{
    public class HeadingStyleTest : Assert
    {
        [Test]
        public void SanityTest()
        {
            HeadingStyle style = new HeadingStyle();
            Assert.NotNull(style);
        }
    }
}