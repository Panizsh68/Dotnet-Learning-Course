using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ShirtsController : ControllerBase
  {
    [HttpGet]
    public string GetShirts()
    {
      return "Reading all the shirts";
    }

    [HttpGet("{id}")]
    // for FromRoute: 
    // [HttpGet("{id}/{color}")]
    public string GetShirtById(int id, [FromHeader(Name = "Color")] string color) // so in header, key is "Color"
    // public string GetShirtById(int id, [FromQuery] string color) so in query, you will do this: ?color=red in the url
    // public string GetShirtById(int id, [FromRoute] string color) this will ensure color is taken from the route
    {
      return $"Reading shirt with id: {id} and color: {color}";
    }

    [HttpPost]
    public string CreateShirt([FromBody]Shirt shirt)
    // public string CreateShirt([FromForm]Shirt shirt)
    {
      return $"Creating a new shirt";
    }

    [HttpPut("{id}")]
    public string UpdateShirt(int id)
    {
      return $"Updating shirt with id: {id}";
    }

    [HttpDelete("{id}")]
    public string DeleteShirt(int id)
    {
      return $"Deleting shirt with id: {id}";
    }
  }
}