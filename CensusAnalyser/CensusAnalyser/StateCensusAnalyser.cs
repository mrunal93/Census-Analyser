using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
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
            string[] numberOfRecords = File.ReadAllLines(filePath);
            return numberOfRecords.Length - 1;
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
