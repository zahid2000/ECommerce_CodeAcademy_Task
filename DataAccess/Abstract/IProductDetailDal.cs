using Core.DataAccess.EntityFramework;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDetailDal:IEntityRepository<ProductDetail>
    {
        List<ReportResponseDto> GetReport(ReportRequestDto reportRequestDto);
    }
}
