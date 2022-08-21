using Business.Abstract;
using Business.Constants;
using Business.FileHelper;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductDetailManager : IProductDetailService
    {
        private IProductDetailDal _productDetailDal;
        private IMailService _mailService;

        public ProductDetailManager(IProductDetailDal productDetailDal, IMailService mailService)
        {
            _productDetailDal = productDetailDal;
            _mailService = mailService;
        }
        public IDataResult<List<ProductDetail>> GetAll()
        {


            var result = _productDetailDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<ProductDetail>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<ProductDetail>>(result);
        }

        public IResult SendReport(ReportRequestDto reportRequestDto)
        {
            var result = BusinessRules.Run(CheckReportType(reportRequestDto), CheckEmails(reportRequestDto.AcceptorEmails), ChechkDates(reportRequestDto));
            if (result != null)
            {
                return result;
            }
            var reportResponseDto = _productDetailDal.GetReport(reportRequestDto);
            SendMail(reportRequestDto, reportResponseDto);

            return new SuccessResult(Messages.SendedReport);
        }
        public IResult Add(ProductDetail productDetail)
        {
            _productDetailDal.Add(productDetail);
            return new SuccessResult(Messages.Added);
        }

        public IResult AddProductDetailsFromExcel(IFormFile file)
        {

            var result = BusinessRules.Run(CheckIfExcelFileExtensionValid(file), CheckFileMemorySize(file), CheckTemplate(file));
            if (result != null)
            {
                return result;
            }
            var productDetails = ExcelHelper.GetProductDetailsFromExcel(file);
            foreach (ProductDetail product in productDetails)
            {
                var addResult = Add(product);
                if (!addResult.Success)
                {
                    return addResult;
                }
            }
            return new SuccessResult();

        }

        private IResult CheckIfExcelFileExtensionValid(IFormFile file)
        {
            bool isValidFileExtension = Messages.ValidExcelFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToUpper());
            if (!isValidFileExtension)
                return new ErrorResult(Messages.InvalidExcelExtension);
            return new SuccessResult();
        }
        private IResult CheckFileMemorySize(IFormFile file)
        {
            bool fileMemorySizeCheckResult = file.Length < 5242880;
            if (!fileMemorySizeCheckResult)
                return new ErrorResult(Messages.FileMemorySizeIsLong);
            return new SuccessResult();
        }
        private IResult CheckTemplate(IFormFile file)
        {
            var result = ExcelHelper.CheckTemplate(file);
            if (!result.Success)
                return result;
            return new SuccessResult();
        }

        private IResult CheckReportType(ReportRequestDto reportRequestDto)
        {
            if (!Enum.IsDefined(typeof(ReportType), reportRequestDto.ReportType))
            {
                return new ErrorResult(Messages.ReportTypeDoesNotExists);
            }
            return new SuccessResult();
        }
        private IResult CheckEmails(string[] emails)
        {
            if (emails.Length == 0)
            {
                return new ErrorResult(Messages.EmailIsNull);
            }
            foreach (string email in emails)
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (!regex.IsMatch(email))
                {
                    return new ErrorResult(Messages.IncorrectEmailType + "(" + email + ")");
                }
                regex = new Regex(@"^([\w\.\-]+)@code.edu.az$");
                if (!regex.IsMatch(email))
                {
                    return new ErrorResult(Messages.EmailIsNotEqual + "(" + email + ")");
                }

            }
            return new SuccessResult();
        }
        private IResult ChechkDates(ReportRequestDto reportRequestDto)
        {
            if (reportRequestDto.StartDate == null || reportRequestDto.EndDate == null)
            {
                return new ErrorResult(Messages.DateMustBeExists);
            }

            int result = DateTime.Compare(reportRequestDto.StartDate, reportRequestDto.EndDate);

            if (result < 0)
                return new SuccessResult();
            else if (result == 0)

                return new SuccessResult(Messages.IsSameDate);
            else
                return new ErrorResult(Messages.IncorrectDateTime);

        }

        private IResult SendMail(ReportRequestDto reportRequestDto, List<ReportResponseDto> reports)
        {
            string? reportType = Enum.GetName(typeof(ReportType), reportRequestDto.ReportType);

            var htmlBody = GetHtmlBody(reportRequestDto, reports);
            Mail mail = new();
            mail.TextBody = reportType + " Hesabat";
            mail.HtmlBody = htmlBody;
            mail.Subject = reportType + " Hesabat"; ;

            foreach (var AcceptorEmail in reportRequestDto.AcceptorEmails)
            {
                mail.ToEmail = AcceptorEmail;
                _mailService.SendMail(mail);
            }

            return new SuccessResult();
        }

        private static string GetHtmlBody(ReportRequestDto reportRequestDto, List<ReportResponseDto> reports)
        {
            string htmlBody;
            string? reportType = Enum.GetName(typeof(ReportType), reportRequestDto.ReportType);
            htmlBody =
                "<h1 align=\"center\" style=\"color: green;\">HESABAT</h1>" +
                "</br>" +
                 "<table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 800 + ">" +
                 "<tr bgcolor='#4da6ff' style=\"color: #fff\">" +
                $"<th><b>{reportType}</b></th> " +
                "<th> <b>Məhsul sayı</b></th>" +
                "<th><b> Endirim toplamı </b></th>" +
                "<th> <b>Satış toplamı </b></th>" +
                "<th> <b>Qazanc toplamı</b> </th>" +
                "</tr>";


            foreach (var report in reports)
            {
                htmlBody += "<tr bgcolor='#fff'  align=\"center\" style=\"width: 100%\">" +
                    $"<td>{report.ReportValue}</td>" +
                    $"<td>{report.ProductCount}</td>" +
                    $"<td>{Math.Round(Convert.ToDecimal(report.TotalDiscount), 2)}" + " $" + "</td>" +
                    $"<td>{Math.Round(Convert.ToDecimal(report.TotalSales), 2)}" + " $" + "</td>" +
                    $"<td>{Math.Round(Convert.ToDecimal(report.TotalProfit), 2)}" + " $" + "</td>" +
                    "</tr> ";
            }
            htmlBody += "</ table > ";

            return htmlBody;
        }

    }
}
