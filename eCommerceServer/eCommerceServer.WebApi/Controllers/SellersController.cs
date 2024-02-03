using ECommerceServer.WebApi.DTOs;
using ECommerceServer.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceServer.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class SellersController : ControllerBase
{
    private readonly ProductRepository _productRepository;
    private readonly OrderRepository _orderRepository;

    public SellersController(ProductRepository productRepository, OrderRepository orderRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    [HttpGet]
    public IActionResult GetAllProducts(Guid userId)
    {
        var result = _productRepository.GetByUserId(userId);
        return Ok(new { statusCode = 200, count = result.Count, products = result });
    }

    [HttpGet]
    public IActionResult GetAllOrders(Guid userId)
    {
        var result = _orderRepository.GetAllBySellerId(userId);
        return Ok(new { statusCode = 200, count = result.Count, products = result });
    }

    [HttpGet]
    public IActionResult GetOrder(Guid Id)
    {
        var result = _orderRepository.GetOrderDetail(Id);
        return Ok(result);
    }


    [HttpPost]
    public IActionResult AddProduct(AddProductDto request)
    {
        try
        {
            _productRepository.Add(request);
            return Ok(new {statusCode = 200, productName = request.Name, message = "Product Added SuccessFully" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult UpdateProduct(UpdateProductDto request)
    {
        try
        {
            _productRepository.Update(request);
            return Ok(new { statusCode = 200, productId = request.Id, message = "Product Updated SuccessFully" });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
