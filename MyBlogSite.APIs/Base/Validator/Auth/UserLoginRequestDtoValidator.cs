using FluentValidation;
using MyBlogSite.Core.Constants;
using MyBlogSite.Core.Dtos.Auth;

namespace Base.Validator.Auth;

public class UserLoginRequestDtoValidator : AbstractValidator<UserLoginRequestDto>
{
    public UserLoginRequestDtoValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage(ValidationMessagesConst.RequiredMessage);
        
        RuleFor(x=> x.Password)
            .NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage);
    }
}