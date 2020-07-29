using CensusAnalyser;
using NUnit.Framework;

namespace CensusAnalyserTest
{
    public class Tests
    {
       
        [Test]
        public void GivenIndiaCensusCSVFile_WhenNumberOfRecordMatch_ShouldReturnTrue()
        {
            string INDIAN_CENSUS_CSVFILE = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\IndiaStateCensusData.csv";
            int csvStateCensusRecords = CSVStateCensus.GetRecord(INDIAN_CENSUS_CSVFILE);
            int stateCensusRecords = StateCensusAnalyser.GetStateCensusRecord(INDIAN_CENSUS_CSVFILE);
            Assert.AreEqual(csvStateCensusRecords, stateCensusRecords);
        }
    }
}