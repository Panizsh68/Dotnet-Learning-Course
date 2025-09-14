using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Validations;

namespace WebApplication1.Models
{
    public class Shirt
    {
        // Primary Key (unique identifier for each shirt)
        // Convention: EF Core (Entity Framework) automatically treats "Id" or "ClassNameId" as the key
        public int ShirtId { get; set; }

        // "string?" means this property CAN be null at the C# language/compiler level.
        // BUT [Required] tells ASP.NET Core model validation that this property MUST be provided in the request body.
        // If not provided (or provided as null/empty), model binding will fail and API will return 400 Bad Request.
        [Required]
        public string? Brand { get; set; }

        // Same logic as above: although "string?" allows null in code,
        // [Required] forces the client to provide this field during request.
        [Required]
        public string? Color { get; set; }

        // Nullable int (int?) → optional field.
        // If client does not send Size, it will be null.
        // No validation here, so it's not required in the request body.
        [Shirt_EnsureCorrectSizing]
        public int? Size { get; set; }

        // Nullable string + [Required] → same pattern:
        // compiler says it *could* be null, but runtime validation demands it NOT be null in client request.
        [Required]
        public string? Gender { get; set; }

        // Nullable double (double?) → fully optional.
        // If client does not send Price in the request, it will simply be null and no validation error will occur.
        public double? Price { get; set; }
    }
}
