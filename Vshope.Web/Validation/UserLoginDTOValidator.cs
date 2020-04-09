using FluentValidation;
using Vshope.Common;
using Vshope.Model.DTO.Auth;

namespace Vshope.Web.Validation
{
    public class UserLoginDTOValidator : AbstractValidator<UserLoginDTO>
    {
        public UserLoginDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().MaximumLength(ConstantsApp.VALIDATION_MAX_LENGTH_SMALL);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(ConstantsApp.VALIDATION_MAX_LENGTH_SMALL);
        }
    }
}
