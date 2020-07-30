using System;

namespace CensusAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Indian Census Analyser");
            string FILE_PATH = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\IndiaStateCensusData.csv";
            int csvStateCensusRecords = CSVStateCensus.GetRecord(FILE_PATH);
            int stateCensusRecords = StateCensusAnalyser.GetStateCensusRecord(FILE_PATH);
            Console.WriteLine("Fetch CSV data for State Census {0} \n state Census Data {1}",csvStateCensusRecords,stateCensusRecords );
        }
    }
}
