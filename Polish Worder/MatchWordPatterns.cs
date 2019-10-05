using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Polish_Worder
{
    class MatchWordPatterns
    {

        public void FindAnagrams(string word)
        {
            int wordLength = word.Length;
            char[] wordInChars = word.ToCharArray();
            wordInChars = wordInChars.OrderBy(o => o).ToArray();
        }

        public void FindPalindromes(string word)
        {

        }
    }
}
