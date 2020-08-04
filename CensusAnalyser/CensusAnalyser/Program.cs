using System;

namespace CensusAnalyser
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Indian Census Analyser");
            string FILE_PATH_STATE_CENSUS = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\Resources\IndiaStateCensusData.csv";
            string FILE_PATH_STATE_CODE = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\Resources\IndiaStateCode.csv";
            string FILE_PATH_US_STATE_CENSUS = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\Resources\USCensusData.csv";

            new JsonStateCensus(FILE_PATH_STATE_CENSUS).SortByState();
            Console.WriteLine("  \n   \n  ");
            new JsonStateCensus(FILE_PATH_STATE_CODE).SortByStateCode();
            Console.WriteLine("  \n   \n  ");
            new JsonStateCensus(FILE_PATH_STATE_CENSUS).SortByStatePopullation();
            Console.WriteLine("  \n   \n  ");
            new JsonStateCensus(FILE_PATH_STATE_CENSUS).SortByStatePopullationDensity();
            Console.WriteLine("  \n   \n  ");
            new JsonStateCensus(FILE_PATH_STATE_CENSUS).SortByStateLagestArea();

            new MostPopularState(FILE_PATH_STATE_CENSUS,FILE_PATH_US_STATE_CENSUS).CombilneCsvFile();

            //int csvStateCensusRecords = CSVStateCensus.GetRecord(FILE_PATH);
            //int stateCensusRecords = StateCensusAnalyser.GetStateCensusRecord(FILE_PATH);
            // Console.WriteLine("Fetch CSV data for State Census {0} \n state Census Data {1}",csvStateCensusRecords,stateCensusRecords );
        }
    }
}
