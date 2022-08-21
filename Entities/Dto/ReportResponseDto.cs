using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class ReportResponseDto:IDto 
    {
        public string? ReportValue { get; set; }
        public int? ProductCount { get; set; }
        public double? TotalDiscount { get; set; }
        public double? TotalProfit { get; set; }
        public double? TotalSales { get; set; }
    }
}
