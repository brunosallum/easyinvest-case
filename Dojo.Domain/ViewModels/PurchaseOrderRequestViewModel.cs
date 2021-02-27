using Dojo.Helpers.BaseModel;
using FluentValidation;

namespace Dojo.Domain.ViewModels
{
    public class PurchaseOrderRequestViewModel : BaseModelValidation
    {
        public string ClientId { get; set; }
        public string ProductId { get; set; }
        public int RequestedAmount { get; set; }
        public override bool IsValid()
        {
            if (ValidationResult == null)
                ValidationResult = new PurchaseOrderRequestViewModelValidator().Validate(this);

            return ValidationResult.IsValid;
        }
    }

    public class PurchaseOrderRequestViewModelValidator : AbstractValidator<PurchaseOrderRequestViewModel>
    {
        public PurchaseOrderRequestViewModelValidator()
        {
            RuleFor(x => x.ProductId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();
            RuleFor(x => x.ClientId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();
            RuleFor(x => x.RequestedAmount)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();
        }
    }
}
