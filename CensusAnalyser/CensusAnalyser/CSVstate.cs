using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class CSVstate
    {
        readonly string path;
        public static int GetRecord(string path)
        {
            try
            {
                int count = 0;
                string[] data = File.ReadAllLines(path);
                IEnumerable<string> record = data;
                foreach (var element in record)
                {
                    if (!element.Contains(","))
                    {
                        throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, "Delimeter is Incorrect ");
                    }
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

        public static void GetFileHeader(string filePath)
        {
            string[] csvData = File.ReadAllLines(filePath);
            string[] alternateCsvData = File.ReadAllLines(filePath);
            IEnumerable<string> records = csvData;
            if (csvData[0] != alternateCsvData[0])
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, "Header Invalid");
            }
        }
    }
}
