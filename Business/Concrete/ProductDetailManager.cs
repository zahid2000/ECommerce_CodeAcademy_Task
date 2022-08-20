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

        public IDataResult<List<ReportResponseDto>> SendReport(ReportRequestDto reportRequestDto)
        {
            var result = _productDetailDal.GetReport(reportRequestDto);
            return new SuccessDataResult<List<ReportResponseDto>>();
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

       
    }
}
