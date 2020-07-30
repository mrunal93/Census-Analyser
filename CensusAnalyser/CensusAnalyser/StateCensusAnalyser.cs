using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        readonly string filePath;
        public StateCensusAnalyser(string filePath)
        {
            this.filePath = filePath;
        }

        public static int GetStateCensusRecord(string filePath)
        {
            try
            {
                string[] numberOfRecords = File.ReadAllLines(filePath);
                return numberOfRecords.Length -1 ;
            }
            catch (DirectoryNotFoundException e)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILEPATH,e.Message);
            }
            catch(FileNotFoundException e)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILENAME, e.Message);
            }
        }



        public static void PrintData(string filePath)
        {
            string[] numberOfRecords = File.ReadAllLines(filePath);
            foreach (var element in numberOfRecords)
            {
                Console.WriteLine(element);

            }

        }


    }
}
