using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class CustomerInsurance
    {
        public int CustomerId { get; set; }

        public string ID { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; }

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
