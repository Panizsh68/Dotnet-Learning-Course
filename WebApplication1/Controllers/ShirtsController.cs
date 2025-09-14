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
      return Ok("Reading all the shirts");
    }

    [HttpGet("{id}")]
    // public Shirt GetShirtById(int id) : this means you want to return only Shirt
    [Shirt_ValidateShirtByIdFilter]
    public IActionResult GetShirtById(int id) // here means you want to return different types of responses
    {
      // return shirts.First(x => x.ShirtId == id); : if not found, it will throw an unfriendly exception
      // if (id <= 0)
      //   return BadRequest();
      // var shirt = ShirtRepository.GetShirtById(id);
      // if (shirt == null)
      //   return NotFound();
      return Ok(ShirtRepository.GetShirtById(id));
    }

    [HttpPost]
    public IActionResult CreateShirt([FromBody]Shirt shirt)
    // public string CreateShirt([FromForm]Shirt shirt)
    {
      return Ok($"Creating a new shirt");
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