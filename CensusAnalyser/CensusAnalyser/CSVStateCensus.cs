using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class CSVStateCensus
    {
        public static int GetRecord(string path)
        {
            int count = 0;
            string[] data = File.ReadAllLines(path);
            IEnumerable<string> record = data;
            foreach(var element in record)
            {
                count++;
            }
            return count - 1;
        }
    }
}
