using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Models;
using WebApplication1.Models.Repositories;

namespace WebApplication1.Filters
{
  public class Shirt_ValidateCreateShirtFilterAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      base.OnActionExecuting(context);

      var shirt = context.ActionArguments["shirt"] as Shirt;

      if (shirt == null)
      {
        context.ModelState.AddModelError("Shirt", "Shirt object is null");
        var problemDetails = new ValidationProblemDetails(context.ModelState)
        {
          Status = StatusCodes.Status400BadRequest
        };
        context.Result = new BadRequestObjectResult(problemDetails);
      }
      else
      {
        var existingShirt = ShirtRepository.GetShirtByProperties(shirt.Brand, shirt.Color, shirt.Gender, shirt.Size);
        if (existingShirt != null)
        {
          context.ModelState.AddModelError("Shirt", "Shirt already exists");
          var problemDetails = new ValidationProblemDetails(context.ModelState)
          {
            Status = StatusCodes.Status400BadRequest
          };
          context.Result = new BadRequestObjectResult(problemDetails);
        }
      }


    }
  }
}