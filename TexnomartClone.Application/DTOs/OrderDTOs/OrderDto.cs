using TexnomartClone.Domain.Entities;

namespace TexnomartClone.Application.DTOs.OrderDTOs;

public class OrderDto : AddOrderDto
{
    public int Id { get; set; }

    public static implicit operator Order(OrderDto dto)
    {
        return new OrderDto()
        {
            Id = dto.Id,
            OrderName = dto.OrderName,
            OrderedDate = dto.OrderedDate,
            UserId = dto.UserId
        };
    }
}