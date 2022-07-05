using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter.Utilities;

namespace WorldCounter.Test
{
    [TestClass]
    public class ByteCalculatorTest
    {
        [TestMethod]
        public void CalculatorTest()
        {
            var result1 = ByteCalculator.SizeSuffix(100, 2);
            var result2 = ByteCalculator.SizeSuffix(1000, 2);
            var result3 = ByteCalculator.SizeSuffix(1000000, 2);
            var result4 = ByteCalculator.SizeSuffix(1000000000, 2);
            var result5 = ByteCalculator.SizeSuffix(1000000000000, 2);
            var result6 = ByteCalculator.SizeSuffix(1000000000000000, 2);
            var result7 = ByteCalculator.SizeSuffix(1000000000000000000, 2);

            Assert.AreEqual("100,00 bytes", result1);
            Assert.AreEqual("0,98 KB", result2);
            Assert.AreEqual("976,56 KB", result3);
            Assert.AreEqual("953,67 MB", result4);
            Assert.AreEqual("931,32 GB", result5);
            Assert.AreEqual("909,49 TB", result6);
            Assert.AreEqual("888,18 PB", result7);
        }
    }
}
