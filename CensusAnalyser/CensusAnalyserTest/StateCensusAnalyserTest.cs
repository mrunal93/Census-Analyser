using CensusAnalyser;
using NUnit.Framework;
using System;

namespace CensusAnalyserTest
{
    public class Tests
    {
        string INDIAN_STATE_CODE = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\Resources\IndiaStateCode.csv";
        string INDIAN_CENSUS_FILEPATH = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\Resources\IndiaStateCensusData.csv";
        string WRONG_FILEPATH = @"C:\Users\Admin\IndiaStateCensusData";
        string WRONG_PATH_CSVFILE_NAME = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\StateCensusData";

      

        [Test]
        public void GivenCsvData_WhenLoaded_ShouldReturnTrue()
        {
            int noOfRecdordsForIndiaCensus = CSVStateCensus.GetReordsForCsvFile(INDIAN_CENSUS_FILEPATH);
            int noOfRecordsForIndiaState = StateCensusAnalyser.GetStateCensusRecord(INDIAN_CENSUS_FILEPATH);
            Assert.AreEqual(noOfRecdordsForIndiaCensus, noOfRecordsForIndiaState);
        }


        [Test]
        public void GivenIvalidPath_WhenLoaded_ShouldReturnExceptionMessage()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyser.CensusAnalyserException>(() => CSVStateCensus.WrongPath(INDIAN_CENSUS_FILEPATH,WRONG_FILEPATH));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, exception.type);
            
        }

        [Test]
        public void GivenIvalidFileName_WhenLoaded_ShouldReturnExceptionMessage()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.GetRecord(WRONG_PATH_CSVFILE_NAME));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILENAME, exception.type);
        }
        
        [Test]
        public void GivenIvalidDelimiter_WhenLoaded_ShouldReturnExceptionMessage()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.GetRecord(INDIAN_CENSUS_FILEPATH));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, exception.type);
        }

        [Test]
        public void GivenIvalidFileHeader_WhenLoaded_ShouldReturnExceptionMessage()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.GetFileHeader(INDIAN_CENSUS_FILEPATH));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, exception.type);
        }

       
        [Test]
        public void GivenIvalidPathToCSVstateClass_WhenLoaded_ShouldReturnExceptionMessage()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => CSVstate.WrongPath(INDIAN_STATE_CODE,WRONG_FILEPATH));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, exception.type);
        }

        [Test]
        public void GivenIvalidFileNameToCSVstateClass_WhenLoaded_ShouldReturnExceptionMessage()
        {
           CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.GetRecord(WRONG_PATH_CSVFILE_NAME));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILENAME, exception.type);
        }

        [Test]
        public void GivenIvalidDelimiterToCSVstateClass_WhenLoaded_ShouldReturnExceptionMessage()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyser.CensusAnalyserException>(() => CSVStateCensus.GetRecord(INDIAN_STATE_CODE));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT,exception.type);
        }

        [Test]
        public void GivenIvalidFileHeaderToCsvStateClass_WhenLoaded_ShouldReturnExceptionMessage()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.GetFileHeader(INDIAN_STATE_CODE));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, exception.type);
        }
    }
}