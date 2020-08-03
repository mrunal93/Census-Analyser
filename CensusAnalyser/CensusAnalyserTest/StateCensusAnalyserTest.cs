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

        [Test]
        public void GivenIndianStateCensusCodeData_WhenLoaded_ShouldReturnStateSortedResult()
        {
            JsonStateCensus jsonState = new JsonStateCensus(INDIAN_CENSUS_FILEPATH);
            string jsonData = jsonState.SortByState();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["State"].ToString();
            Assert.AreEqual("Andhra Pradesh", firstValueFromCsv);


        }

        [Test]
        public void GivenIndianStateCodeData_WhenLoaded_ShouldReturnStateSortedResult()
        {
            JsonStateCensus jsonState = new JsonStateCensus(INDIAN_STATE_CODE);
            string jsonData = jsonState.SortByState();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["StateName"].ToString();
            Assert.AreEqual("Andaman and Nicobar Islands", firstValueFromCsv);
        }

        [Test]
        public void UCStateCodeData_WhenLoaded_ShouldReturnStateSortedResult()
        {
            JsonStateCensus jsonState = new JsonStateCensus(US_STATE_CENSUS);
            string jsonData = jsonState.SortByState();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["State"].ToString();
            Assert.AreEqual("Alabama", firstValueFromCsv);
        }

        [Test]
        public void UCStateCodeData_WhenLoaded_ShouldReturnSortedResultByPopulation()
        {
            JsonStateCensus jsonState = new JsonStateCensus(US_STATE_CENSUS);
            string jsonData = jsonState.SortUSCensusDataByPopulousState();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["Population"].ToString();
            Assert.AreEqual("1052567", firstValueFromCsv);
        }

        [Test]
        public void UCStateCodeDataPopulationDensity_WhenLoaded_ShouldReturnSortedResultByPopulationDensity()
        {
            JsonStateCensus jsonState = new JsonStateCensus(US_STATE_CENSUS);
            string jsonData = jsonState.SortUSCensusDataByPopulousDensity();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["PopulationDensity"].ToString();
            Assert.AreEqual("0.46", firstValueFromCsv);
        }

        [Test]
        public void UCStateCodeDataTotalArea_WhenLoaded_ShouldReturnSortedResultByTotalArea()
        {
            JsonStateCensus jsonState = new JsonStateCensus(US_STATE_CENSUS);
            string jsonData = jsonState.SortUSCensusDataByTotalArea();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["TotalArea"].ToString();
            Assert.AreEqual("104655.80", firstValueFromCsv);
        }

        [Test]
        public void UCStateCodeDataWaterArea_WhenLoaded_ShouldReturnSortedResultByWaterArea()
        {
            JsonStateCensus jsonState = new JsonStateCensus(US_STATE_CENSUS);
            string jsonData = jsonState.SortUSCensusDataByWaterArea();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["WaterArea"].ToString();
            Assert.AreEqual("1026.21", firstValueFromCsv);
        }

        [Test]
        public void UCStateCodeDataLandArea_WhenLoaded_ShouldReturnSortedResultByLandArea()
        {
            JsonStateCensus jsonState = new JsonStateCensus(US_STATE_CENSUS);
            string jsonData = jsonState.SortUSCensusDataByWaterArea();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["LandArea"].ToString();
            Assert.AreEqual("294207.53", firstValueFromCsv);
        }
    }
}