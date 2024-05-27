using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private static readonly List<Order> orders = new List<Order>();

    [HttpGet]
    public ActionResult<IEnumerable<Order>> Get() => orders;

    [HttpGet("{id}")]
    public ActionResult<Order> Get(int id)
    {
        var order = orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
            return NotFound();
        return order;
    }

    [HttpPost]
    public ActionResult<Order> Post(Order order)
    {
        order.Id = orders.Count + 1;
        orders.Add(order);
        return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
    }
}
