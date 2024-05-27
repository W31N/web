using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Product1", Price = 10.0m },
        new Product { Id = 2, Name = "Product2", Price = 20.0m }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get() => products;

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();
        return product;
    }

    [HttpPost]
    public ActionResult<Product> Post(Product product)
    {
        product.Id = products.Count + 1;
        products.Add(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }
}
