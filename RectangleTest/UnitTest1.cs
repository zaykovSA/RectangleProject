using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RectangleProject;

namespace RectangleTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RectangleIsProper()
        {
            var randomiser = new Random();
            var firstLine = randomiser.Next(1, 10) * randomiser.NextDouble();
            var secondLine = randomiser.Next(1, 10) * randomiser.NextDouble();
            var thirdLine = Math.Sqrt(Math.Pow(firstLine, 2) + Math.Pow(secondLine, 2));
            var expected = 0.5 * firstLine * secondLine;

            var rect = new Rectangle(firstLine, secondLine, thirdLine);

            var actual = rect.Square;
            Assert.AreEqual(expected, actual, 0.0001, "Square is not correct");
        }

        [TestMethod]
        public void RectangleIsNotProper()
        {
            var randomiser = new Random();
            var firstLine = randomiser.Next(1, 10) * randomiser.NextDouble();
            var secondLine = randomiser.Next(1, 10) * randomiser.NextDouble();
            var thirdLine = randomiser.Next(1, 10) * randomiser.NextDouble();
            while (thirdLine == Math.Sqrt(Math.Pow(firstLine, 2) + Math.Pow(secondLine, 2)))
                thirdLine = randomiser.Next(1, 10) * randomiser.NextDouble();

            var rect = new Rectangle(firstLine, secondLine, thirdLine);

            var actual = rect.IsRectangle;
            Assert.AreEqual(false, actual, "Square is not correct");
        }

        [TestMethod]
        public void RectangleIsALine()
        {
            var randomiser = new Random();
            const int firstLine = 0;
            var secondLine = randomiser.Next(1, 10) * randomiser.NextDouble();
            var thirdLine = randomiser.Next(1, 10) * randomiser.NextDouble();

            var rect = new Rectangle(firstLine, secondLine, thirdLine);

            var actual = rect.Square;
            Assert.AreEqual(0, actual, "Square is not correct");
        }
    }
}
