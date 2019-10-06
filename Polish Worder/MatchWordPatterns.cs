using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Polish_Worder
{
    class MatchWordPatterns
    {
        public List<string> MatchingWords { get; private set; } = new List<string>();
        //private static List<string> dictionaryEntries = new List<string>();
        private string dictionaryEntry = null;


        public void FindAnagrams(string word)
        {
            int counter = 0;

            word.ToLower();
            int wordLength = word.Length;
            char[] wordInChars = word.ToCharArray();
            wordInChars = wordInChars.OrderBy(o => o).ToArray();

            StreamReader sr = new StreamReader("odm.txt");
            while((this.dictionaryEntry = sr.ReadLine()) != null)
            {
                if (wordLength == dictionaryEntry.Length)
                {
                    if (wordInChars.SequenceEqual(dictionaryEntry.ToCharArray().OrderBy(o => o).ToArray()))
                    {
                        MatchingWords.Add(dictionaryEntry.ToString());
                        counter++;
                    }
                }
            }
        }

        public void FindPalindromes(string word)
        {

        }
    }
}
