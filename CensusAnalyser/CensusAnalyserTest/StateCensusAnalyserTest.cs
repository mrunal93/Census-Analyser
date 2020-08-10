using CensusAnalyser;
using Newtonsoft.Json.Linq;
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
        string US_STATE_CENSUS = @"C:\Users\Admin\Documents\Census-Analyser\CensusAnalyser\CensusAnalyser\Resources\USCensusData.csv";
      

        [Test]
        public void GivenCsvData_WhenLoaded_ShouldReturnTrue()
        {
            int noOfRecdordsForIndiaCensus = CSVStateCensus.GetLenghtOFCsvFile(INDIAN_CENSUS_FILEPATH);
            int noOfRecordsForIndiaState = CSVStateCensus.GetLenghtOFCsvFile(INDIAN_CENSUS_FILEPATH);
            Assert.AreEqual(noOfRecdordsForIndiaCensus, noOfRecordsForIndiaState);
        }


        [Test]
        public void GivenIvalidPath_WhenLoaded_ShouldReturnExceptionMessage()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyser.CensusAnalyserException>(() => CSVStateCensus.WrongPath(INDIAN_CENSUS_FILEPATH,WRONG_FILEPATH));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, exception.type);
            
        }

        [Test]
        public void GivenIvalidDelimiter_WhenLoaded_ShouldReturnExceptionMessage()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.GetRecordForCsvFile(INDIAN_CENSUS_FILEPATH));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, exception.type);
        }

        [Test]
        public void GivenIvalidFileHeader_WhenLoaded_ShouldReturnExceptionMessage()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.GetFileHeader(INDIAN_CENSUS_FILEPATH));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, exception.type);
        }

        [Test]
        public void GivenIvalidFileNameToCSVstateClass_WhenLoaded_ShouldReturnExceptionMessage()
        {
           CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.GetRecordForCsvFile(WRONG_PATH_CSVFILE_NAME));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILENAME, exception.type);
        }

        [Test]
        public void GivenIvalidDelimiterToCSVstateClass_WhenLoaded_ShouldReturnExceptionMessage()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyser.CensusAnalyserException>(() => CSVStateCensus.GetRecordForCsvFile(INDIAN_STATE_CODE));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT,exception.type);
        }

        [Test]
        public void GivenIvalidFileHeaderToCsvStateClass_WhenLoaded_ShouldReturnExceptionMessage()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => CSVStateCensus.GetFileHeader(INDIAN_STATE_CODE));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, exception.type);
        }
       
        [Test]
        public void UCStateCodeData_WhenLoaded_ShouldReturnSortedResultByPopulation()
        {
            JsonCensusAnalyser jsonState = new JsonCensusAnalyser(US_STATE_CENSUS);
            string jsonData = jsonState.SortUSCensusDataByPopulousState();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["Population"].ToString();
            Assert.AreEqual("1052567", firstValueFromCsv);
        }

        [Test]
        public void UCStateCodeDataPopulationDensity_WhenLoaded_ShouldReturnSortedResultByPopulationDensity()
        {
            JsonCensusAnalyser jsonState = new JsonCensusAnalyser(US_STATE_CENSUS);
            string jsonData = jsonState.SortUSCensusDataByPopulousDensity();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["PopulationDensity"].ToString();
            Assert.AreEqual("0.46", firstValueFromCsv);
        }

        [Test]
        public void UCStateCodeDataTotalArea_WhenLoaded_ShouldReturnSortedResultByTotalArea()
        {
            JsonCensusAnalyser jsonState = new JsonCensusAnalyser(US_STATE_CENSUS);
            string jsonData = jsonState.SortUSCensusDataByTotalArea();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["TotalArea"].ToString();
            Assert.AreEqual("104655.80", firstValueFromCsv);
        }

        [Test]
        public void UCStateCodeDataWaterArea_WhenLoaded_ShouldReturnSortedResultByWaterArea()
        {
            JsonCensusAnalyser jsonState = new JsonCensusAnalyser(US_STATE_CENSUS);
            string jsonData = jsonState.SortUSCensusDataByWaterArea();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["WaterArea"].ToString();
            Assert.AreEqual("1026.21", firstValueFromCsv);
        }

        [Test]
        public void UCStateCodeDataLandArea_WhenLoaded_ShouldReturnSortedResultByLandArea()
        {
            JsonCensusAnalyser jsonState = new JsonCensusAnalyser(US_STATE_CENSUS);
            string jsonData = jsonState.SortUSCensusDataByWaterArea();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["LandArea"].ToString();
            Assert.AreEqual("294207.53", firstValueFromCsv);
        }
    }
}