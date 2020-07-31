using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CensusAnalyser
{
    class JsonStateCensus
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


        public void SortByState()
        {
            var listOb = JsonConvert.DeserializeObject<List<JsonObjectForSateCensus>>(CsvToJSON());
            var descListOb = listOb.OrderBy(x => x.State);
            Console.WriteLine(JsonConvert.SerializeObject(descListOb));
        }

        public void SortByStateCode()
        {
            var listOfStateCode = JsonConvert.DeserializeObject<List<JsonStateCode>>(CsvToJSON());
            var descListOfStateCode = listOfStateCode.OrderBy(x => x.StateCode);
            Console.WriteLine(JsonConvert.SerializeObject(descListOfStateCode));
        }
       
        public void SortByStatePopullation()
        {
            var listOb = JsonConvert.DeserializeObject<List<JsonObjectForSateCensus>>(CsvToJSON());
            var descListOb = listOb.OrderBy(x => x.Population);
            Console.WriteLine(JsonConvert.SerializeObject(descListOb));
        }

        public void SortByStatePopullationDensity()
        {
            var listOb = JsonConvert.DeserializeObject<List<JsonObjectForSateCensus>>(CsvToJSON());
            var descListOb = listOb.OrderBy(x => x.DensityPerSqKm);
            Console.WriteLine(JsonConvert.SerializeObject(descListOb));
        }

    }
}
