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
        public void DownloadDictionary()
        {
            if (!File.Exists("odm.txt"))
            {
                WebClient webC = new WebClient();
                string sourceCode = webC.DownloadString("https://sjp.pl/slownik/odmiany");
                string file = Regex.Match(sourceCode, "sjp-odm-[0-9]+.zip").ToString();
                webC.DownloadFile("https://sjp.pl/slownik/odmiany/" + file, "odm.zip");
                ZipFile.ExtractToDirectory("odm.zip", "odm");
                File.Move("odm/odm.txt", "odm.txt");
                File.Delete("odm.zip");
                Directory.Delete("odm", true);
            }
        }
    }
}
