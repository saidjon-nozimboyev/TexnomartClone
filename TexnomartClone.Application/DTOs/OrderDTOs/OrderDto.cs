using TexnomartClone.Domain.Entities;

namespace TexnomartClone.Application.DTOs.OrderDTOs;

public class OrderDto : AddOrderDto
{
    public int Id { get; set; }

    public static implicit operator OrderDto(Order dto)
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