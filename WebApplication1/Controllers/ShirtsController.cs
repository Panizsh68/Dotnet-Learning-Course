using Microsoft.AspNetCore.Mvc;

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
    public string GetShirtById(int id)
    {
      return $"Reading shirt with id: {id}";
    }

    [HttpPost]
    public string CreateShirt()
    {
      return "Creating a new shirt";
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