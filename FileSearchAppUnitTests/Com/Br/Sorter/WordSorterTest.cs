using Com.Br.Counter;
using Com.Br.Reader;
using Com.Br.Sorter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearchAppUnitTests.Com.Br.Sorter
{
    public class WordSorterTest
    {

        private WordSorter _wordSorter;

        [SetUp]
        public void SetUp()
        {
            _wordSorter = new WordSorter();
        }

        [Test]
        public void WordSorter_SortTheSingleResult()
        {
            var wordResult = new Dictionary<string, int>();
            wordResult.Add("Broadridge",1);            
            var sortResult = _wordSorter.Sorter(wordResult);
            Assert.AreEqual(wordResult, sortResult);
        }

        [Test]
        public void WordSorter_SortTheResults()
        {
            var wordResult = new Dictionary<string, int>();
            wordResult.Add("Solutions", 2);
            wordResult.Add("Broadridge", 1);
            

            var wordExpectedResult = new Dictionary<string, int>();
            wordExpectedResult.Add("Broadridge", 1);
            wordExpectedResult.Add("Solutions", 2);

            var sortResult = _wordSorter.Sorter(wordResult);
            Assert.AreEqual(wordExpectedResult, sortResult);
        }

        [Test]
        public void WordSorter_Empty()
        {
            var wordResult = new Dictionary<string, int>();           
            var sortResult = _wordSorter.Sorter(wordResult);
            Assert.AreEqual(wordResult, sortResult);
        }

    }
}
