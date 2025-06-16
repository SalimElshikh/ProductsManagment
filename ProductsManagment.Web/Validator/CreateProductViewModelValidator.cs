using FluentValidation;
using ProductsManagment.Web.ViewModels;

namespace ProductsManagment.Web.Validator;

public class CreateProductViewModelValidator : AbstractValidator<CreateProductViewModel>
{
    public CreateProductViewModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("اسم المنتج مطلوب")
            .MaximumLength(100).WithMessage("اسم المنتج لا يزيد عن 100 حرف");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("السعر يجب أن يكون أكبر من صفر");

        RuleFor(x => x.CreatedOn)
            .NotEmpty().WithMessage("تاريخ الإنشاء مطلوب");

        RuleFor(x => x.ServiceProviderId)
            .GreaterThan(0).WithMessage("يجب اختيار مقدم خدمة");
    }
}