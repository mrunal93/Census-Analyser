using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class CensusDAO
    {
        public string State { get; set; }
        public string Population { get; set; }
        public string AreaInSqKm { get; set; }
        public string DensityPerSqKm { get; set; }
        public string SrNo { get; set; }
        public string TIN { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public string StateId { get; set; }
        public string HousingUnits { get; set; }
        public string TotalArea { get; set; }
        public string WaterArea { get; set; }
        public string LandArea { get; set; }
        public string PopulationDensity { get; set; }
        public string HousingDensity { get; set; }

        public CensusDAO(CSVIndianSateCensusModel cSVIndianSateCensusModel)
        {
            this.State = cSVIndianSateCensusModel.State;
            this.Population = cSVIndianSateCensusModel.Population;
            this.AreaInSqKm = cSVIndianSateCensusModel.AreaInSqKm;
            this.DensityPerSqKm = cSVIndianSateCensusModel.DensityPerSqKm;
        }

        public CensusDAO(CsvIndianSateCodeModel csvIndianSateCode)
        {
            this.SrNo = csvIndianSateCode.SrNo;
            this.TIN = csvIndianSateCode.TIN;
            this.StateName = csvIndianSateCode.StateName;
            this.StateCode = csvIndianSateCode.StateCode;
        }

        public CensusDAO(CsvUsCensusModel csvUsCensusModel)
        {
            this.StateId = csvUsCensusModel.StateId;
            this.State = csvUsCensusModel.State;
            this.Population = csvUsCensusModel.Population;
            this.HousingDensity = csvUsCensusModel.HousingDensity;
            this.HousingUnits = csvUsCensusModel.HousingUnits;
            this.TotalArea = csvUsCensusModel.TotalArea;
            this.WaterArea = csvUsCensusModel.WaterArea;
            this.LandArea = csvUsCensusModel.LandArea;
            this.PopulationDensity = csvUsCensusModel.PopulationDensity;
        }

    }
}
