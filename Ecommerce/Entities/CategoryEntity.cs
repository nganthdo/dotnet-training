using System;

namespace Ecommerce.Entities;

public class CategoryEntity
{
    public int Id { get; set; }
    public required string Name { get; set;} 
    //required: It specifies that this property must be assigned a value when creating an instance of the class containing this property

}
