
using LIB.FileWordAnalyzer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Tests
{
    [TestClass]
    public class SectionAnalyserTests
    {
        [TestMethod]
        public void TestSegmentAnalyser()
        {
            var analyser = new AnalyzerSection();
            var results = analyser.Analyze(GetSegments()).ToList();
            var option1 = results.FirstOrDefault(x => x.Key == "abc");
            var option2 = results.FirstOrDefault(x => x.Key == "def");

            Assert.IsNotNull(option1);
            Assert.IsNotNull(option2);
            Assert.AreEqual(20, option1.Value);
            Assert.AreEqual(15, option2.Value);

            IEnumerable<string> GetSegments()
            {
                for (int i = 0; i < 20; i++)
                {
                    yield return "abc";
                }

                for (int i = 0; i < 15; i++)
                {
                    yield return "def";
                }
            }
        }
    }
}
