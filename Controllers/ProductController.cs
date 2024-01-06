using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebApi.Models;

namespace ProductManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Category> _categories = new List<Category>()
        {

        new Category() { Id = 1, Name = "Bilgisayar", IsStatus = true },
        new Category() { Id = 2, Name = "Telefon", IsStatus = true },
        new Category() { Id = 3, Name = "Tablet", IsStatus = true },
        new Category() { Id = 4, Name = "Beyaz Eşya", IsStatus = false },

};
        public static List<Product> _products = new List<Product>()
        {
            new Product() {Id = 1, Name = "Pardus", Price = 10, Stock = 3, IsStatus = true, CategoryId = 1 },
            new Product() {Id = 2, Name = "Samsung", Price = 20, Stock = 4, IsStatus = true, CategoryId = 2  },
            new Product() {Id = 3, Name = "Samsung S6-Lite", Price = 30, Stock = 6, IsStatus = true, CategoryId = 3  },
            new Product() {Id = 4, Name = "Gece Lambası", Price = 40, Stock = 9, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 5, Name = "Lenova", Price = 30, Stock = 9, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 6, Name = "Huawei", Price = 80, Stock = 9, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 7, Name = "Tabs", Price = 9, Stock = 3, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 8, Name = "A", Price = 56, Stock = 4, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 9, Name = "S", Price = 34, Stock = 5, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 10, Name = "D", Price = 76, Stock = 6, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 11, Name = "G ", Price = 87, Stock = 7, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 12, Name = "H J", Price = 88, Stock = 8, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 13, Name = "Gece Lambası", Price = 40, Stock = 9, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 14, Name = "Gece Lambası", Price = 40, Stock = 9, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 15, Name = "Gece Lambası", Price = 40, Stock = 9, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 16, Name = "Gece Lambası", Price = 40, Stock = 9, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 17, Name = "Gece Lambası", Price = 40, Stock = 9, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 18, Name = "Tabs", Price = 9, Stock = 3, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 19, Name = "Tabs", Price = 9, Stock = 3, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 20, Name = "Tabs", Price = 9, Stock = 3, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 21, Name = "Tabs", Price = 9, Stock = 3, IsStatus = false, CategoryId = 4  },
            new Product() {Id = 22, Name = "Tabs", Price = 9, Stock = 3, IsStatus = false, CategoryId = 4  },

        };

        [HttpGet]
        //..api/product

        public IEnumerable<Product> GetAll()
        {
            //  return _products.Where(x => x.IsStatus).ToList();
            return _products.ToList();
        }

        [HttpGet("{id}")]

        public Product GetById(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            return product;
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {

            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                _products.Remove(product);
                return StatusCode(200); //başarılı

            }
            else
            {
                return StatusCode(404); //başarısız
            }
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            if (!String.IsNullOrEmpty(product.Name))
            {
                _products.Add(product);
                return Ok("Ekleme Başarılı");
            }
            else
            {
                return Ok("Category Name Boş Olamaz");
            }
        }

        [HttpPut]

        public IActionResult Put(Product product)
        {
            var findCategory = _products.FirstOrDefault(x => x.Id == product.Id);
            if (findCategory != null)
            {
                findCategory.Name = product.Name;
                findCategory.Price = product.Price;
                findCategory.Stock = product.Stock;
                findCategory.IsStatus = product.IsStatus;
                findCategory.CategoryId = product.CategoryId;
                return Ok(product.Name + " Kategori başarılı bir şekilde eklendi");
            }
            else
            {
                return Ok(" Category Bulunamadı");
            }
        }

        [HttpPut("{id}")]

        public IActionResult Put2(int id, Product product)
        {
            var findCategory = _categories.FirstOrDefault(x => x.Id == id);

            var findProduct = _products.FirstOrDefault(x => x.Id == id);
            if (findProduct != null)
            {
                findProduct.Name = product.Name;
                findProduct.Price = product.Price;
                findProduct.Stock = product.Stock;
                findProduct.IsStatus = product.IsStatus;
                findCategory.Id = product.CategoryId;
                return Ok(product.Name + " Kategorisi başarılı bir şekilde eklendi");
            }
            else
            {
                return Ok(" Category Bulunamadı");
            }
        }
    }
}
