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

        public ProductDetailManager(IProductDetailDal productDetailDal)
        {
            _productDetailDal = productDetailDal;
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
            var reportResult = _productDetailDal.GetReport(reportRequestDto);
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

        public IResult Delete(ProductDetail productDetail)
        {
            throw new NotImplementedException();
        }

        public IResult Update(ProductDetail productDetail)
        {
            throw new NotImplementedException();
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


    }
}
