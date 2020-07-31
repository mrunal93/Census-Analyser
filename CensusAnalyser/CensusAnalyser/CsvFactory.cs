using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    class CsvFactory: CsvBuilder
    {
        char exceptionType;
        public  CsvFactory(char exceptionType)
        {
            this.exceptionType = exceptionType;
        }

        public void CheckForException()
        {
            switch (exceptionType)
            {
                case 'H':
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, "Invalid Header");
                case 'W':
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, "Invalid File Path");
                case 'N':
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILENAME, "Invalid File Name");
                case 'D':
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, "Delimiter Incorrect");
                default:
                    break;
            }
        }

    }
}
