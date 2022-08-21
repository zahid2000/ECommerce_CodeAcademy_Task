using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProductDetailDal : EFEntityRepositoryBase<ProductDetail, ECommerceContext>, IProductDetailDal
    {
        public List<ReportResponseDto> GetReport(ReportRequestDto reportRequestDto)
        {
            using (ECommerceContext context = new())
            {
                int reportType = reportRequestDto.ReportType;


                // var result = context.ProductDetails.FromSqlRaw("select "+reportType+",count(*) count ,sum(Discounts) discount,sum(Profit) profit ,sum(Sales) sales from ProductDetails  where Date>='" + reportRequestDto.StartDate + "' and Date<='" + reportRequestDto.EndDate + "' group by " + reportType + "").ToList<object>();
                var result = context.ProductDetails
                    .Where(x => x.Date >= reportRequestDto.StartDate && x.Date <= reportRequestDto.EndDate)
                    .GroupBy(x => reportType == 1 ? x.Segment : reportType == 2 ? x.Country : reportType == 3 ? x.Product : reportType == 4 ? x.DiscountBand : x.Country)
               .Select(x => new ReportResponseDto
               {
                   ReportValue = x.Key,
                   ProductCount = x.Count(),
                   TotalSales = x.Sum(s => s.Sales),
                   TotalDiscount = x.Sum(s => s.Discounts),
                   TotalProfit = x.Sum(s => s.Profit),
               })
               .ToList();

                return result;
            }

        }

    }
}
