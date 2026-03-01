using MyLibrary;

namespace MyLibraryTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]              // Test Attribute
        public void Test1()
        {
            //A Arrange
            MyMath math = new MyMath();
            int expected = 22;
            int actual = 0;

            //A Act
            actual = math.GetSum(4,5,6,7);

            //A Assert
            Assert.AreEqual(expected, actual);

            //Assert.Pass();
        }
        [Test]
        public void Test2()
        {
            //A Arrange
            MyMath math = new MyMath();
            int expected = -3;
            int actual = 0;

            //A Act
            actual = math.GetSum(-2,-1);

            //A Assert
            Assert.AreEqual(expected, actual);

            //Assert.Pass();
        }
        [TestCase(2,1,2)]
        [TestCase(-1, -3, 3)]
        [TestCase(2, 3, 6)]
        public void TestMultiply(int n1, int n2, int expected)
        {
            //A Arrange
            MyMath math = new MyMath();
            //int expected = 2;
            int actual = 0;

            //A Act
            actual = math.GetMultiply(n1, n2);

            //A Assert
            Assert.AreEqual(expected, actual);

            //Assert.Pass();
        }
    }
}