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
            Assert.AreEqual(stateCensusRecords, csvStateCensusRecords);
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
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, e.type);
            }
        }

        [Test]
        public void GivenIvalidFileName_WhenLoaded_ShouldReturnExceptionMessage()
        {
            try
            {
                string INDIAN_CENSUS_CSVFILE = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\StateCensusData.csv";
                int csvStateCensusRecords = CSVStateCensus.GetRecord(INDIAN_CENSUS_CSVFILE);
                int stateCensusRecords = StateCensusAnalyser.GetStateCensusRecord(INDIAN_CENSUS_CSVFILE);
                Assert.AreEqual(csvStateCensusRecords, stateCensusRecords);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILENAME, e.type);
            }
        }
        
        [Test]
        public void GivenIvalidDelimiter_WhenLoaded_ShouldReturnExceptionMessage()
        {
            try
            {
                string INDIAN_CENSUS_CSVFILE = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\IndiaStateCensusData.csv";
                int csvStateCensusRecords = CSVStateCensus.GetRecord(INDIAN_CENSUS_CSVFILE);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, e.type);
            }
        }

        [Test]
        public void GivenIvalidFileHeader_WhenLoaded_ShouldReturnExceptionMessage()
        {
            try
            {
                string INDIAN_CENSUS_CSVFILE = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\IndiaStateCensusData.csv";
                int csvStateCensusRecords = CSVStateCensus.GetRecord(INDIAN_CENSUS_CSVFILE);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, e.type);
            }
        }

        [Test]
        public void GivenIndiaCensusCSVFileToCSVstateClass_WhenNumberOfRecordMatch_ShouldReturnTrue()
        {
            string INDIAN_CENSUS_CSVFILE = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\IndiaStateCensusData.csv";
            int csvStateCensusRecords = CSVstate.GetRecord(INDIAN_CENSUS_CSVFILE);
            int stateCensusRecords = StateCensusAnalyser.GetStateCensusRecord(INDIAN_CENSUS_CSVFILE);
            Assert.AreEqual(stateCensusRecords, csvStateCensusRecords);
        }

        [Test]
        public void GivenIvalidPathToCSVstateClass_WhenLoaded_ShouldReturnExceptionMessage()
        {
            try
            {
                string INDIAN_CENSUS_CSVFILE = @"C:\Users\Admin\";
                int csvStateCensusRecords = CSVstate.GetRecord(INDIAN_CENSUS_CSVFILE);
                int stateCensusRecords = StateCensusAnalyser.GetStateCensusRecord(INDIAN_CENSUS_CSVFILE);
                Assert.AreEqual(csvStateCensusRecords, stateCensusRecords);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, e.type);
            }
        }

        [Test]
        public void GivenIvalidFileNameToCSVstateClass_WhenLoaded_ShouldReturnExceptionMessage()
        {
            try
            {
                string INDIAN_CENSUS_CSVFILE = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\StateCensusData.csv";
                int csvStateCensusRecords = CSVstate.GetRecord(INDIAN_CENSUS_CSVFILE);
                int stateCensusRecords = StateCensusAnalyser.GetStateCensusRecord(INDIAN_CENSUS_CSVFILE);
                Assert.AreEqual(csvStateCensusRecords, stateCensusRecords);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILENAME, e.type);
            }
        }

        [Test]
        public void GivenIvalidDelimiterToCSVstateClass_WhenLoaded_ShouldReturnExceptionMessage()
        {
            try
            {
                string INDIAN_CENSUS_CSVFILE = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\IndiaStateCensusData.csv";
                int csvStateCensusRecords = CSVstate.GetRecord(INDIAN_CENSUS_CSVFILE);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, e.type);
            }
        }

        [Test]
        public void GivenIvalidFileHeaderToCsvStateClass_WhenLoaded_ShouldReturnExceptionMessage()
        {
            try
            {
                string INDIAN_CENSUS_CSVFILE = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\IndiaStateCensusData.csv";
                int csvStateCensusRecords = CSVstate.GetRecord(INDIAN_CENSUS_CSVFILE);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, e.type);
            }
        }
    }
}