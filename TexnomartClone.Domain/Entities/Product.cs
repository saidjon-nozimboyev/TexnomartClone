using TexnomartClone.Domain.Entities;

namespace TexnomartClone.Domain.Enums;

public class Product : Base
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }   
    public int Piece { get; set; }
    public double Rating { get; set; }
}
