using ConsoleApp;
using System.ComponentModel.DataAnnotations;

namespace UnitTest
{
    [TestClass]
    public class KataFirstUniqueTest
    {
        [TestMethod]
        public void TestSolution()
        {
            var kataFirstUnique = new KataFirstUnique();
            int[] intArrayA = { 4, 10, 5, 4, 2, 10 };
            var expected = 5;
            var actual = kataFirstUnique.Solution(intArrayA);
            Assert.AreEqual(expected, actual, 0, "Error message Sasasa");

            int[] intArrayB = { 4, 10, 5, 5, 3, 4, 2, 10 };
            expected = 3;
            actual = kataFirstUnique.Solution(intArrayB);
            Assert.AreEqual(expected, actual, 0, "Error message Sasasa");

            int[] intArrayC = { 4, 10, 5, 4, 2, 10, 5, 2, 7 };
            expected = 7;
            actual = kataFirstUnique.Solution(intArrayC);
            Assert.AreEqual(expected, actual, 0, "Error message Sasasa");
        }
    }
}