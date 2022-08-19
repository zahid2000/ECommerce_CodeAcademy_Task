using Core.Utilities.Results;
using Entities;
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
        
        IResult AddProductDetailsFromExcel(IFormFile file);
        IResult Add(ProductDetail productDetail);
        IResult Update(ProductDetail productDetail);    
        IResult Delete(ProductDetail productDetail);
    }
}
