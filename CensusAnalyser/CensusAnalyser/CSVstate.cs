using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class CSVstate
    {
        readonly string path;
        readonly string wrongPath;
        public static int GetRecord(string path)
        {

            if (!path.EndsWith(".csv"))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILENAME, "INvalid File Name");
            }
            int count = 0;
            string[] data = File.ReadAllLines(path);
            IEnumerable<string> record = data;
            foreach (var element in record)
            {
                if (!element.Contains(":"))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, "Delimeter is Incorrect ");
                }
                count++;
            }
            return count - 1;
        }


        public static void WrongPath(string path, string wrongPath)
        {
            if (path != wrongPath)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, "Invalid File Path");
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
