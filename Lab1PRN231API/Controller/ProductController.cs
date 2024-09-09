using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Services;
using Services.Implement;

namespace Lab1PRN231API.Controller;
[Route("api/v1/products")]
public class ProductController : ControllerBase {
    private readonly IProductService productService;
    public ProductController () {
        productService = new ProductService();
    }
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts() {
        return productService.GetProducts();
    }
    [HttpPost]
    public IActionResult PostProduct(Product p) {
        productService.SaveProduct(p);
        return NoContent();
    }
    [HttpDelete("id")]
    public IActionResult RemoveProduct(int id) {
        var p = productService.GetProductById(id);
        if (p == null) return NotFound();
        productService.RemoveProduct(p);
        return NoContent();
    }
    [HttpPut("id")]
    public IActionResult UpdateProduct(int id, Product p) {
        var temp = productService.GetProductById(id);
        if (p == null) {
            return NotFound();
        }
        productService.UpdateProduct(p);
        return NoContent();
    }
}