using FluentValidation;

using ProductsManagment.Web.ViewModels;

namespace ProductsManagment.Web.Validator;
public class FilterProductViewModelValidator : AbstractValidator<FilterProductViewModel>
{
    public FilterProductViewModelValidator()
    {
        RuleFor(x => x.MinPrice)
            .GreaterThanOrEqualTo(0).When(x => x.MinPrice.HasValue)
            .WithMessage("الحد الأدنى للسعر لا يمكن أن يكون أقل من صفر");

        RuleFor(x => x.MaxPrice)
            .GreaterThan(x => x.MinPrice ?? 0)
            .When(x => x.MaxPrice.HasValue && x.MinPrice.HasValue)
            .WithMessage("الحد الأقصى للسعر يجب أن يكون أكبر من الحد الأدنى");

        RuleFor(x => x.DateTo)
            .GreaterThanOrEqualTo(x => x.DateFrom!.Value)
            .When(x => x.DateFrom.HasValue && x.DateTo.HasValue)
            .WithMessage("تاريخ النهاية يجب أن يكون بعد أو يساوي تاريخ البداية");
    }
}

