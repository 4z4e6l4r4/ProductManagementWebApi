using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebApi.Models;
using System;

namespace ProductManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPaginationController : ControllerBase
    {
        [HttpGet("{page}")]
        public ProductPaginationModel Get(int page = 1)
        {
            var model = new ProductPaginationModel();

            var productCount = 2;
            var productSkip = (page - 1) * productCount;

            model.CurrentPage = page;

            model.PageCount = (int)Math.Ceiling(ProductController._products.Count / 2.0);
            model.TotalProductCount = ProductController._products.Count;
            model.Products = ProductController._products.Skip(productSkip).Take(productCount).ToList();
            return model;
        }
    }
}
