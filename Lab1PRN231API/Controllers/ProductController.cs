using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using Models.Entities;
using Services;

namespace Lab1PRN231API.Controllers;
[ApiController]
[Route("api/v1/products")]
public class ProductController(IProductService productService, ICategoryService categoryService) : ControllerBase {
    private readonly IProductService productService = productService;
    private readonly ICategoryService categoryService = categoryService;

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts() {
        return productService.GetProducts();
    }
    [HttpPost]
    public IActionResult PostProduct(ProductDto p) {
        Product temp = new()
        {
            CategoryId = p.CategoryId,
            ProductName = p.ProductName,
            UnitPrice = p.UnitPrice,
            UnitsInStock = p.UnitsInStock
        };
        var category = categoryService.GetCategoryById(p.CategoryId);
        if(category == null) return Ok("Not Found Category");
        temp.Category = category;
        productService.SaveProduct(temp);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult RemoveProduct(int id) {
        var p = productService.GetProductById(id);
        if (p == null) return NotFound();
        productService.RemoveProduct(p);
        return NoContent();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, ProductDto p) {
        var temp = productService.GetProductById(id);
        if (p == null) {
            return NotFound();
        }
        temp.ProductName = p.ProductName;
        temp.CategoryId = p.CategoryId;
        temp.UnitPrice = p.UnitPrice;
        temp.UnitsInStock = p.UnitsInStock;
        var category = categoryService.GetCategoryById(p.CategoryId);
        if(category == null) return Ok("Not Found Category");
        temp.Category = category;
        productService.UpdateProduct(temp);
        return NoContent();
    }
}