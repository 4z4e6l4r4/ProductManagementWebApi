using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchProductController : ControllerBase
    {
        private static List<Product> _products = new List<Product>()
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

        //[HttpGet]
        //public IActionResult SearchProducts([FromQuery] string search)
        //{
        //    if (string.IsNullOrWhiteSpace(search))
        //    {
        //        return BadRequest("Arama terimi boş olamaz.");
        //    }

        //    // Harf sırasına göre filtreleme (kelimelerin ilk harflerine göre eşleşme yapılıyor)
        //    var result = _products
        //        .Where(p => IsMatchFirstLetters(p.Name, search))
        //        .Select(p => new Product { Id = p.Id, Name = p.Name })
        //        .ToList();

        //    if (result.Count == 0)
        //    {
        //        return NotFound("Arama sonucu bulunamadı.");
        //    }

        //    return Ok(result);
        //}

        //private bool IsMatchFirstLetters(string source, string target)
        //{
        //    // Boşluklara göre ayır ve her kelimenin ilk harfini al
        //    var sourceFirstLetters = source.Split(' ').Select(word => word.FirstOrDefault());

        //    // Hedef kelimenin ilk harflerini al
        //    var targetFirstLetters = target.Split(' ').Select(word => word.FirstOrDefault());

        //    // İki liste arasında eşleşme kontrolü yap
        //    return sourceFirstLetters.SequenceEqual(targetFirstLetters, StringComparer.OrdinalIgnoreCase);
        //}
    }
}
