using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var lines = File.ReadAllLines(path);

            foreach (string line in lines)
                csv.Add(line.Split(','));

            var properties = lines[0].Split(',');

            var listObjResult = new List<Dictionary<string, string>>();

            for (int rows = 1; rows < lines.Length; rows++)
            {
                var objResult = new Dictionary<string, string>();
                for (int columns = 0; columns < properties.Length; columns++)
                    objResult.Add(properties[columns], csv[rows][columns]);

                listObjResult.Add(objResult);
            }
            return JsonConvert.SerializeObject(listObjResult);
            
        }


        public void SortByState()
        {
            var listOb = JsonConvert.DeserializeObject<List<JsonObj>>(CsvToJSON());
            var descListOb = listOb.OrderBy(x => x.State);
            Console.WriteLine(JsonConvert.SerializeObject(descListOb));
        }
    }
}
