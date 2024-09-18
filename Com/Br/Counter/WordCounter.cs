using System.Collections.Generic;

namespace Com.Br.Counter
{
    public class WordCounter
    {
        public static Dictionary<string, int> wordCountStore = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        public static async Task<Dictionary<string, int>> Counter(string inputLine)
        {

            if (string.IsNullOrWhiteSpace(inputLine))
            {
                return wordCountStore;
            }
            
            string[] wordTerms = inputLine.Split(new[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string wordTerm in wordTerms)
            {
                string word = wordTerm.Trim().ToLower();

                if (wordCountStore.ContainsKey(word))
                {
                    wordCountStore[word]++;
                    continue;
                }
                
                wordCountStore[word] = 1;                
            }            

            return wordCountStore;
        }
    }
}