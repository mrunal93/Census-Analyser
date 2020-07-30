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
            try
            {
                int count = 0;
                string[] data = File.ReadAllLines(path);
                IEnumerable<string> record = data;
                foreach (var element in record)
                {
                    count++;
                }
                return count - 1;
            }
            catch (DirectoryNotFoundException e)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, e.Message);
            }
            catch (FileNotFoundException e)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILENAME, e.Message);
            }
        }
    }
}
