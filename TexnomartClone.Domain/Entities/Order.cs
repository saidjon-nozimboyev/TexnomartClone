namespace TexnomartClone.Domain.Entities;

public class Order : Base
{
    public int UserId { get; set; }
    public int OrderId { get; set; }
    public string OrderName { get; set; } = string.Empty;
    public DateTime OrderedDate { get; set; }
}
