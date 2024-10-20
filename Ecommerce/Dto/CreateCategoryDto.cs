using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dto;

public record class CreateCategoryDto (
    
    [Required][StringLength(20)]string Name
    );

