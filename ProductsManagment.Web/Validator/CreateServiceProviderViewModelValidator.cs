namespace ProductsManagment.Web.Validator;
using FluentValidation;
using ProductsManagment.Web.ViewModels;

public class CreateServiceProviderViewModelValidator : AbstractValidator<CreateServiceProviderViewModel>
{
    public CreateServiceProviderViewModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("اسم مقدم الخدمة مطلوب")
            .MaximumLength(100).WithMessage("الاسم لا يزيد عن 100 حرف");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("العنوان مطلوب");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("رقم الهاتف مطلوب")
            .Matches(@"^01[0125]\d{8}$").WithMessage("رقم الهاتف غير صالح");
    }
}
