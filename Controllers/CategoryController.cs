using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebApi.Models;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace ProductManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private static List<Category> _categories = new List<Category>()
        {

        new Category() { Id = 1, Name = "Bilgisayar", IsStatus = true },
        new Category() { Id = 2, Name = "Telefon", IsStatus = true },
        new Category() { Id = 3, Name = "Tablet", IsStatus = true },
        new Category() { Id = 4, Name = "Beyaz Eşya", IsStatus = false },

};


        [HttpGet]
        //..api/Category
        public IEnumerable<Category> GetAll()
        {

            return _categories.ToList();

            //var category = new Category()
            //{
            //    Id = 1,
            //    Name = "Blgisayar",
            //};
        }

        [HttpGet("{id}")]

        public Category GetById(int id)
        {
            var category = _categories.FirstOrDefault(x => x.Id == id);

            return category;
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {

            var category = _categories.FirstOrDefault(x => x.Id == id);
            if (category != null)
            {
                _categories.Remove(category);
                return StatusCode(200); //başarılı

            }
            else
            {
                return StatusCode(404); //başarısız
            }
        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            if (!String.IsNullOrEmpty(category.Name))
            {
                _categories.Add(category);
                return Ok("Ekleme Başarılı");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]

        public IActionResult Put(Category category)
        {
            var findCategory = _categories.FirstOrDefault(x => x.Id == category.Id);
            if (findCategory != null)
            {
                findCategory.Name = category.Name;
                findCategory.IsStatus = category.IsStatus;
                return Ok(category.Name + " Kategori başarılı bir şekilde eklendi");
            }
            else
            {
                return Ok(" Category Bulunamadı");
            }
        }

        [HttpPut("{id}")]

        public IActionResult Put2(int id, Category category)
        {
            var findCategory = _categories.FirstOrDefault(x => x.Id == id);
            if (findCategory != null)
            {
                findCategory.Name = category.Name;
                findCategory.IsStatus = category.IsStatus;
                return Ok(category.Name + " Kategorisi başarılı bir şekilde eklendi");
            }
            else
            {
                return Ok(" Category Bulunamadı");
            }
        }

    }
}
