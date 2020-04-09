using FluentValidation;
using Vshope.Common;
using Vshope.Model.DTO.Main;

namespace Vshope.Web.Validation
{
    public class CompanyDTOValidator : AbstractValidator<CompanyDTO>
    {
        public CompanyDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(ConstantsApp.VALIDATION_MAX_LENGTH_SMALL);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(ConstantsApp.VALIDATION_MIN_LENGTH_PASSWORD)
                .MaximumLength(ConstantsApp.VALIDATION_MAX_LENGTH_SMALL);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(ConstantsApp.VALIDATION_MAX_LENGTH_SMALL);
            RuleFor(x => x.Address).MaximumLength(ConstantsApp.VALIDATION_MAX_LENGTH_NORMAL);
            RuleFor(x => x.ContactPhone).MaximumLength(ConstantsApp.VALIDATION_MAX_LENGTH_NORMAL);
            RuleFor(x => x.ManagerName).MaximumLength(ConstantsApp.VALIDATION_MAX_LENGTH_NORMAL);
            RuleFor(x => x.ProductAdditionalDesc).MaximumLength(ConstantsApp.VALIDATION_MAX_LENGTH_BIG);
            RuleFor(x => x.VkStr).MaximumLength(ConstantsApp.VALIDATION_MAX_LENGTH_SMALL);
        }
    }
}
