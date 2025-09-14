using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filters;
using WebApplication1.Models;
using WebApplication1.Models.Repositories;

namespace WebApplication1.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ShirtsController : ControllerBase
  {
    [HttpGet]
    public IActionResult GetShirts()
    {
      return Ok(ShirtRepository.GetShirts());
    }

    [HttpGet("{id}")]
    [Shirt_ValidateShirtByIdFilter]
    public IActionResult GetShirtById(int id) 
    {
      return Ok(ShirtRepository.GetShirtById(id));
    }

    [HttpPost]
    [Shirt_ValidateCreateShirtFilter]
    public IActionResult CreateShirt([FromBody] Shirt shirt)
    {
      ShirtRepository.AddShirt(shirt);
      return CreatedAtAction(nameof(GetShirtById), new { id = shirt.ShirtId }, shirt);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateShirt(int id)
    {
      return Ok($"Updating shirt with id: {id}");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteShirt(int id)
    {
      return Ok($"Deleting shirt with id: {id}");
    }
  }
}