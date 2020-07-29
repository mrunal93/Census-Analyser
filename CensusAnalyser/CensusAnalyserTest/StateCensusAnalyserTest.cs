using CensusAnalyser;
using NUnit.Framework;
using System;

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

        [Test]
        public void GivenIvalidPath_WhenLoaded_ShouldReturnExceptionMessage()
        {
            try 
            {
                string INDIAN_CENSUS_CSVFILE = @"C:\Users\Admin\";
                int csvStateCensusRecords = CSVStateCensus.GetRecord(INDIAN_CENSUS_CSVFILE);
                int stateCensusRecords = StateCensusAnalyser.GetStateCensusRecord(INDIAN_CENSUS_CSVFILE);
                Assert.AreEqual(csvStateCensusRecords, stateCensusRecords);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Invalid Directory");
            }
        }
    }
}