namespace Com.Br.Counter
{
    public class WordSorter
    {

        public static Dictionary<string, int> Sorter(Dictionary<string, int> wordCountResult)
        {
            if (wordCountResult != null)
            {
                var wordCountResultSorted = wordCountResult.OrderBy(word => word.Key).ToDictionary(pair => pair.Key, pair => pair.Value);

                return wordCountResultSorted;
            }

            return wordCountResult;
        }

    }
}