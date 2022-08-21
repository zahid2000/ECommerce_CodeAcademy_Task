using Core.Utilities.Results;
using Entities;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductDetailService
    {
        IDataResult<List<ProductDetail>> GetAll();
        IResult SendReport(ReportRequestDto reportRequestDto);
        IResult AddProductDetailsFromExcel(IFormFile file);
        IResult Add(ProductDetail productDetail);
    }
}
