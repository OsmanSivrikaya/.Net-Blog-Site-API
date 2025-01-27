using FluentValidation;
using MyBlogSite.Core.Constants;
using MyBlogSite.Core.Dtos.Auth;

namespace Base.Validator.Auth;

public class UserResetPasswordRequestDtoValidator : AbstractValidator<UserResetPasswordRequestDto>
{
    public UserResetPasswordRequestDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage(ValidationMessagesConst.RequiredMessage);
    }   
}