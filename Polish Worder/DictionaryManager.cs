using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Polish_Worder
{
    class DictionaryManager
    {
        public const string DictionaryName = "odm.txt";

        public void DownloadDictionary()
        {
            if (!File.Exists(DictionaryName))
            {
                WebClient webC = new WebClient();
                string sourceCode = webC.DownloadString("https://sjp.pl/slownik/odmiany");
                string file = Regex.Match(sourceCode, "sjp-odm-[0-9]+.zip").ToString();
                webC.DownloadFile("https://sjp.pl/slownik/odmiany/" + file, "odm.zip");
                ZipFile.ExtractToDirectory("odm.zip", "odm");
                File.Move("odm/" + DictionaryName, DictionaryName);
                File.Delete("odm.zip");
                Directory.Delete("odm", true);

                NormalizeDictionary();
            }
        }

        private void NormalizeDictionary()
        {
            char[] specialCharaktersThatSplitWords = { ',', ' ', '\r', '\n' };

            string file = File.ReadAllText(DictionaryName);
            //string[] dictionaryEntries = file.Split(specialCharaktersThatSplitWords);
            //dictionaryEntries = dictionaryEntries.Where(w => w != "").Select(s => s.ToLower()).ToArray();
            //dictionaryEntries.Distinct();

            HashSet<string> dictionaryEntries = file.Split(specialCharaktersThatSplitWords).ToHashSet();
            dictionaryEntries = dictionaryEntries.Where(w => w != "" && !w.Contains("?")).Select(s => s.ToLower()).ToHashSet();

            File.WriteAllLines(DictionaryName, dictionaryEntries);
            dictionaryEntries = null;
            GC.Collect();
        }
    }
}
