using AcceptingOrdersForDeliveryMVC.Models;
using AcceptingOrdersForDeliveryMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcceptingOrdersForDeliveryMVC.Controllers;

public class OrdersController : Controller
{
    private readonly OrderService orderService;

    public OrdersController(OrderService orderService)
    {
        this.orderService = orderService;
    }

    private static List<Order> orders = new List<Order>();
    private static int nextId = 1;

    public async Task<IActionResult> Index()
    {
        var orders = await orderService.GetOrdersAsync();
        return View(orders);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Order order)
    {
        if (ModelState.IsValid)
        {
            await orderService.CreateOrderAsync(order);
            return RedirectToAction("Index");
        }
        return View(order);
    }

    public async Task<IActionResult> Details(int id)
    {
        var order = await orderService.GetOrderAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return View(order);
    }
}
