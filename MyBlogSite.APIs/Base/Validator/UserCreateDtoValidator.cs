using FluentValidation;
using MyBlogSite.Core.Constants;
using MyBlogSite.Core.Dtos.User;

namespace MyBlogSite.Validator
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotNull().NotEmpty().WithMessage(ValidationMessagesConst.RequiredMessage)
                .Length(1, 50).WithMessage(ValidationMessagesConst.LengthMessage);

            RuleFor(x => x.Password)
                .NotNull().NotEmpty().WithMessage(ValidationMessagesConst.RequiredMessage)
                .Length(1, 50).WithMessage(ValidationMessagesConst.LengthMessage);

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage(ValidationMessagesConst.RequiredMessage);
        }
    }
}
