using FluentValidation;
using MyBlogSite.Core.Constants;
using MyBlogSite.Core.Dtos.Auth;

namespace Base.Validator.Auth;

public class UserResetPasswordApproveRequestDtoValidator : AbstractValidator<UserResetPasswordApproveRequestDto>
{
    public UserResetPasswordApproveRequestDtoValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage(ValidationMessagesConst.RequiredMessage);
        
        RuleFor(x => x.Pass1)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .Matches(RegexConst.PasswordRegex)
            .WithMessage(ValidationMessagesConst.PasswordApprove);

        RuleFor(x => x.Pass2)
            .NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage);

        RuleFor(x => x.Pass1)
            .Equal(x => x.Pass2)
            .WithMessage("Şifreler birbirleriyle eşleşmelidir.");
    }
}