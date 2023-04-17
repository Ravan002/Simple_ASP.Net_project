using Application.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validation.FluentValidation
{
    public class CreateOrderValidator : AbstractValidator<VM_Create_Order>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Musteri id girilmek zorunda")
                .Must(x => x > 0)
                    .WithMessage("0 dan buyuk olmali");
        }
    }
}
