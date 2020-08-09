using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace CensusAnalyser
{
    public class CSVStateCensus
    {
        public static void GetRecordForCsvFile(string path,[Optional] string nullPath )
        {
            if (nullPath != null)
            {
                if (path != nullPath)
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, "File Path is Null");
                }
            }
            if (!path.EndsWith(".csv"))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILENAME,"INvalid File Name");
            }
            string[] data = File.ReadAllLines(path);
            IEnumerable<string> record = data;
            foreach (var element in record)
            {
                if (!element.Contains(":"))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, "Delimeter is Incorrect ");
                }
            }  
        }

        public static int GetLenghtOFCsvFile(string path)
        {
            string[] noOfRecordsForIndianCensus = File.ReadAllLines(path);
            return noOfRecordsForIndianCensus.Length - 1;
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
            string CSV_DATA_HEADER = "State, Population, AreaInSqKm, DensityPerSqKm";
            if (csvData[0] != CSV_DATA_HEADER)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, "Header Invalid");
            }
        }
    }
}
