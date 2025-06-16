namespace ProductsManagment.Web.Validator.ServiceProviders;
using FluentValidation;
using ProductsManagment.Web.ViewModels.ServiceProviders;

public class CreateServiceProviderViewModelValidator : AbstractValidator<CreateServiceProviderViewModel>
{
    public CreateServiceProviderViewModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("اسم مقدم الخدمة مطلوب")
            .Length(3, 100)
            .WithMessage("العنوان يجب ان لا يقل عن 3 احرف ولا يزيد عن 100");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("العنوان مطلوب")
            .Length(3, 100)
            .WithMessage("العنوان يجب ان لا يقل عن 3 احرف ولا يزيد عن 100");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("رقم الهاتف مطلوب")
            .Matches(@"^01[0125]\d{8}$").WithMessage("رقم الهاتف غير صالح");
    }
}
