using System;

namespace Entities
{
    public class Insurance
    {
        public int InsuranceID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal CoveragePercentage { get; set; }

        public DateTime StartDate { get; set; }

        public int CoverageTime { get; set; }

        public decimal Amount { get; set; }

        public int RiskTypeID { get; set; }

        public bool State { get; set; }
    }
}
