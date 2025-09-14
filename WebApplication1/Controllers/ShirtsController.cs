using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ShirtsController : ControllerBase
  {
    private List<Shirt> shirts = new List<Shirt>()
    {
      new Shirt {ShirtId = 1, Brand = "My Brand", Color = "Blue", Gender = "Male", Price = 30, Size = 10},
      new Shirt {ShirtId = 2, Brand = "My Brand", Color = "Black", Gender = "Male", Price = 35, Size = 12},
      new Shirt {ShirtId = 3, Brand = "Your Brand", Color = "Pink", Gender = "Female", Price = 28, Size = 8},
      new Shirt {ShirtId = 4, Brand = "Your Brand", Color = "Yellow",  Gender = "Female", Price = 30, Size = 9},
    };

    [HttpGet]
    public IActionResult GetShirts()
    {
      return Ok("Reading all the shirts");
    }

    [HttpGet("{id}")]
    // public Shirt GetShirtById(int id) : this means you want to return only Shirt
    public IActionResult GetShirtById(int id) // here means you want to return different types of responses
    {
      // return shirts.First(x => x.ShirtId == id); : if not found, it will throw an unfriendly exception
      if (id <= 0)
        return BadRequest();
      var shirt = shirts.FirstOrDefault(x => x.ShirtId == id);
      if (shirt == null)
        return NotFound();
      return Ok(shirt);
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