using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        public CensusAnalyserException()
        {
        }
        public enum ExceptionType
        {
            INVALID_FILEPATH,INVALID_FILENAME
        }
        public ExceptionType type;

        public CensusAnalyserException(ExceptionType type ,string message) : base(message)
        {
            this.type = type;
        }
        }
    }

