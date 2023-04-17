using Application.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validation.FluentValidation
{
    public class CreateBookValidator : AbstractValidator<VM_Create_Book>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Author).NotEmpty().NotNull().WithMessage("Muellif adini bos buraxmiyin!!");
            RuleFor(x => x.Price).Must(x=>x>0).WithMessage("Price 0 dan boyuk olmalidir.");
        }
    }
}
