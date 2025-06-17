using FluentValidation;
using ProductsManagment.Web.ViewModels;

namespace ProductsManagment.Web.Validator.Products;

public class CreateProductViewModelValidator : AbstractValidator<CreateProductViewModel>
{
    public CreateProductViewModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("اسم الخدمة مطلوب")
            .Length(3, 100)
            .WithMessage("الاسم يجب ان لا يقل عن 3 احرف ولا يزيد عن 100");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("السعر يجب أن يكون أكبر من صفر");

        RuleFor(x => x.CreatedOn)
            .NotEmpty().WithMessage("تاريخ الإنشاء مطلوب");

        RuleFor(x => x.ServiceProviderId)
            .GreaterThan(0).WithMessage("يجب اختيار مقدم خدمة");
    }
}