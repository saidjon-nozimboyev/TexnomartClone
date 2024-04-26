using FluentValidation;
using TexnomartClone.Domain.Entities;

namespace TexnomartClone.Application.Common.Validators;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {

        RuleFor(o => o.UserId)
            .GreaterThan(0)
            .WithMessage("UserId must be greater than 0.");

        RuleFor(o => o.OrderId)
            .GreaterThan(0)
            .WithMessage("OrderId must be greater than 0.");

        RuleFor(o => o.OrderName)
            .NotEmpty()
            .WithMessage("OrderName cannot be empty.");

        RuleFor(o => o.OrderedDate)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("OrderedDate cannot be in the future.");
    }
}
