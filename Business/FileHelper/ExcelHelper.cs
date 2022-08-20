using Business.Constants;
using Core.Utilities.Results;
using Entities;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FileHelper
{
    public class ExcelHelper
    {
        public static List<ProductDetail> GetProductDetailsFromExcel(IFormFile file)
        {
            List<ProductDetail> productDetails = new List<ProductDetail>();
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {

                        productDetails.Add(new ProductDetail
                        {

                            Segment = worksheet.Cells[row, 1].Value.ToString()?.Trim(),
                            Country = worksheet.Cells[row, 2].Value.ToString()?.Trim(),
                            Product = worksheet.Cells[row, 3].Value.ToString()?.Trim(),
                            DiscountBand = worksheet.Cells[row, 4].Value.ToString()?.Trim(),
                            UnitsSold = Convert.ToDouble(worksheet.Cells[row, 5].Value),
                            ManufacturingPrice = Convert.ToDouble(worksheet.Cells[row, 6].Value),
                            SalePrice = Convert.ToDouble(worksheet.Cells[row, 7].Value),
                            GrossSales = Convert.ToDouble(worksheet.Cells[row, 8].Value),
                            Discounts = Convert.ToDouble(worksheet.Cells[row, 9].Value),
                            Sales = Convert.ToDouble(worksheet.Cells[row, 10].Value),
                            COGS = Convert.ToDouble(worksheet.Cells[row, 11].Value),
                            Profit = Convert.ToDouble(worksheet.Cells[row, 12].Value),
                            Date = Convert.ToDateTime(worksheet.Cells[row, 13].Value)

                        });
                    }
                }
            }
            return productDetails;
        }

        public static IResult CheckTemplate(IFormFile file)
        {
            List<ProductDetail> productDetails = new List<ProductDetail>();
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(stream))
                {
                    string[] productDetailsTemplateValues = { "segment", "country", "product", "discount band", "units sold",
                        "manufacturing price","sale price","gross sales", "discounts","sales","cogs","profit","date"};
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    for (int i = 0; i < worksheet.Dimension.Columns; i++)
                    {
                        var result = CheckTemplateHeader(worksheet.Cells[1, i + 1].Value.ToString()!, productDetailsTemplateValues[i]);
                        if (!result.Success)
                        {
                            return result;
                        }
                    }
                }
                return new SuccessResult();
            }
        }

        private static IResult CheckTemplateHeader(string header, string checkingValue)
        {
            if (header.ToString().Trim().ToLower().Equals(checkingValue.ToString().Trim().ToLower()))
            {
                return new SuccessResult();
            }
            return new ErrorResult("'" + header + "' sütünu verilmiş şablona uyğun gəlmir!");
        }
    }
}
