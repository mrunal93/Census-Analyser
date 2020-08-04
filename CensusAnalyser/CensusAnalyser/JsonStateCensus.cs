using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CensusAnalyser
{
    public class JsonStateCensus : ICsvHelper
    {
        string path;
        public JsonStateCensus(string path)
        {
            this.path = path;
        }
        public string CsvToJSON()
        {
            var csv = new List<string[]>();
            var csvData = File.ReadAllLines(path);

            foreach (string line in csvData)
                csv.Add(line.Split(','));

            var properties = csvData[0].Split(',');

            var listStateCensus = new List<Dictionary<string, string>>();

            for (int rows = 1; rows < csvData.Length; rows++)
            {
                var objResult = new Dictionary<string, string>();
                for (int columns = 0; columns < properties.Length; columns++)
                    objResult.Add(properties[columns], csv[rows][columns]);

                listStateCensus.Add(objResult);
            }
            return JsonConvert.SerializeObject(listStateCensus);
            
        }

        public string SortByState()
        {
            var listOb = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var descListOb = listOb.OrderBy(x => x.State);
            return JsonConvert.SerializeObject(descListOb);
        }

        public string SortByStateCode()
        {
            var listOfStateCode = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var descListOfStateCode = listOfStateCode.OrderBy(x => x.StateCode);
            return JsonConvert.SerializeObject(descListOfStateCode);
        }
       
        public string SortByStatePopullation()
        {
            var listOb = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var descListOb = listOb.OrderBy(x => x.Population);
            return JsonConvert.SerializeObject(descListOb);
        }

        public string SortByStatePopullationDensity()
        {
            var listOb = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var descListOb = listOb.OrderBy(x => x.DensityPerSqKm);
            return JsonConvert.SerializeObject(descListOb);
        }

        public string SortByStateLagestArea()
        {
            var listOb = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var descListOb = listOb.OrderBy(x => x.AreaInSqKm);
            return JsonConvert.SerializeObject(descListOb);
        }

        public string SortUSCensusDataByPopulousState()
        {
            var listOb = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var ascListOb = listOb.OrderBy(x => x.Population);
            return JsonConvert.SerializeObject(ascListOb);
        }

        public string SortUSCensusDataByPopulousDensity()
        {
            var listOb = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var ascListOb = listOb.OrderBy(x => x.PopulationDensity);
            return JsonConvert.SerializeObject(ascListOb);
        }

        public string SortUSCensusDataByTotalArea()
        {
            var listOb = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var ascListOb = listOb.OrderBy(x => x.TotalArea);
            return JsonConvert.SerializeObject(ascListOb);
        }

        public string SortUSCensusDataByWaterArea()
        {
            var listOb = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var ascListOb = listOb.OrderBy(x => x.WaterArea);
            return JsonConvert.SerializeObject(ascListOb);
        }

        public string SortUSCensusDataByLandArea()
        {
            var listOb = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var ascListOb = listOb.OrderBy(x => x.LandArea);
            return JsonConvert.SerializeObject(ascListOb);
        }
    }
}
