using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace CensusAnalyser
{
    public class Merging
    {

        readonly string pathForFirstCSv, pathForSecondCsv;
        List<string> line = new List<string>();
        private string merge_file;
        private int count;

        public  Merging(string pathForFirstCsv, string pathForSecondCSv)
        {
            this.pathForFirstCSv = pathForFirstCsv;
            this.pathForSecondCsv = pathForSecondCSv;
        }

        public void CombilneCsvFile()
        {
            string[] CsvData = File.ReadAllLines(pathForFirstCSv);
            line.Add("State,Population,AreaInSqKm,DensityPerSqKm");
            string[] csvFileSecond = File.ReadAllLines(pathForSecondCsv);
            string[] csvFileFirst = File.ReadAllLines(pathForFirstCSv);
            for (int length =1; length < csvFileSecond.Length; length++)
            {
                count = 0;
                string[] readCsvFileSecond = csvFileSecond[length].Split(',');
                for ( int lengthTwo=1; lengthTwo < csvFileFirst.Length; lengthTwo++)
                {
                    string[] readCsvFileFirst = csvFileFirst[lengthTwo].Split(',');
                }

                if (count == 0)
                {
                    string add = String.Concat(csvFileFirst[length]);
                    line.Add(add);
                }
                File.WriteAllLines(merge_file, line);
            }
            Console.WriteLine(" ");
        }


        public void merge(string code, string census, string[] readIndiaCensus, string[] readUsStateCensus)
        {
            if (readIndiaCensus[0] == readUsStateCensus[1])
            {
                int indexCount = census.IndexOf(",");
                string StartIndex = census.Substring(indexCount);
                string concat = String.Concat(code, StartIndex);
                line.Add(concat);
                count = 1;
            }
        }
    }
}

    