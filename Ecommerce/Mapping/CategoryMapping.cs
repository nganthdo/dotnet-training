using System;
using System.CodeDom.Compiler;
using Ecommerce.Dto;
using Ecommerce.Entities;

namespace Ecommerce.Mapping;

public static class CategoryMapping
{
    public static CategoryEntity ToCategoryEntity(this CreateCategoryDto categoryEntity)
    {
          return new CategoryEntity()
            {
                Name = categoryEntity.Name
            };
    }

    public static CategoryEntity ToCategoryEntity(this UpdateCategoryDto categoryEntity, int id)
    {
          return new CategoryEntity()
            {
                Id = id,
                Name = categoryEntity.Name
            };
    }

    public static CategoryDto ToDto(this CategoryEntity category)
    {
        return new (category.Id, category.Name);
    }


}
