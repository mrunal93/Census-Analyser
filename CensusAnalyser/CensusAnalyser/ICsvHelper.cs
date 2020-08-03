using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    interface ICsvHelper
    {
        public string SortByState();
        public string SortByStateCode();
        public string SortByStatePopullation();
        public string SortByStatePopullationDensity();
        public string SortByStateLagestArea();
    }
}
