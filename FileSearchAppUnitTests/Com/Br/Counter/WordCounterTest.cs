using Com.Br.Counter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearchAppUnitTests.Com.Br.Counter
{
    public class WordCounterTest
    {
        private WordCounter _counter;

        [SetUp]
        public void SetUp()
        {
            _counter = new WordCounter();
        }


        [Test]
        public async Task WordCounter_ShouldReturnEmptyDictionary_WhenInputIsEmpty()
        {
            var emptyCounterResult = await _counter.Counter(string.Empty);
            Assert.That(emptyCounterResult, Is.Not.Null);
        }

        [Test]
        public async Task WordCounter_ShouldReturnCountOfEachWords()
        {
            var caseSensitiveResult = await _counter.Counter("Broadridge Financial Solutions United Kingdom");

            Assert.AreEqual(1, caseSensitiveResult["Broadridge"]);
            Assert.AreEqual(1, caseSensitiveResult["Financial"]);
            Assert.AreEqual(1, caseSensitiveResult["Solutions"]);
            Assert.AreEqual(1, caseSensitiveResult["United"]);
            Assert.AreEqual(1, caseSensitiveResult["Kingdom"]);
        }

        [Test]
        public async Task WordCounter_ShouldReturnCountOfEachWordsCaseInsensitivity()
        {
            var caseInSensitiveResult = await _counter.Counter("Broadridge Financial Solutions United Kingdom");

            Assert.AreEqual(1, caseInSensitiveResult["broadridge"]);
            Assert.AreEqual(1, caseInSensitiveResult["financial"]);
            Assert.AreEqual(1, caseInSensitiveResult["solutions"]);
            Assert.AreEqual(1, caseInSensitiveResult["united"]);
            Assert.AreEqual(1, caseInSensitiveResult["kingdom"]);

        }

        [Test]
        public async Task WordCounter_MustIgnoreExtraSpaces()
        {
            var extraSpaceResult = await _counter.Counter("   Broadridge   Solutions  ");

            Assert.AreEqual(1, extraSpaceResult["Broadridge"]);
            Assert.AreEqual(1, extraSpaceResult["Solutions"]);
        }
    }
}
