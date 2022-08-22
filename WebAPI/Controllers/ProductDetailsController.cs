using Business.Abstract;
using Entities.Dto;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private IProductDetailService _productDetailService;
        private  ILogger<ProductDetailsController> _logger;

        public ProductDetailsController(IProductDetailService productDetailService,ILogger<ProductDetailsController> logger)
        {
            _productDetailService = productDetailService;
            _logger = logger;
        }

        [HttpPost("UploadData")]
        public IActionResult AddProductDetailsFromExcel(IFormFile file)
        {
            _logger.LogInformation("Accepted UploadData Request");

            var result =_productDetailService.AddProductDetailsFromExcel(file);
            if (result.Success)
            {
                _logger.LogInformation("Return success Response from UploadData Request ");
                return Ok(result);
            }
            _logger.LogError("Return unsucces Response from UploadData Request ");
            return BadRequest(result);
        }
        

        [HttpPost("sendreport")]
        public IActionResult SendReport(ReportRequestDto reportRequestDto)
        {
            _logger.LogInformation("Accepted SendReport Request");

            var result = _productDetailService.SendReport(reportRequestDto);
            if (result.Success)
            {
                _logger.LogInformation("Return success Response from SendReport Request ");
                return Ok(result);
            }
            _logger.LogError("Return unsucces Response from SendReport Request ");
            return BadRequest(result);
        }
    }
}
