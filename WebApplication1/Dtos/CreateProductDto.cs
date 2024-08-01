using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
}
