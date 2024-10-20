

using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dto;

public record class UpdateCategoryDto (
    
    [Required][StringLength(20)]string Name
    );

