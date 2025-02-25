using FluentValidation;
using MyBlogSite.Business.Services.Services;
using MyBlogSite.Core.Constants;
using MyBlogSite.Core.Dtos.User;
using MyBlogSite.Core.Enums;
using MyBlogSite.Core.Helpers;

namespace Base.Validator.User;

public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateDtoValidator(UserService userService)
    {
        RuleFor(x => x.Id)
            .Cascade(CascadeMode.Stop)
            .NotEqual(Guid.Empty)
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .MustAsync(async (userId, cancellation) => await userService.BeExisting(userId, cancellation))
            .WithMessage("Kullanıcı bulunamadı!");
        
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage);
        
        RuleFor(x => x.Surname)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage);
        
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .Length(1, 200)
            .WithMessage(ValidationMessagesConst.LengthMessage)
            .MustAsync(async (user, email, cancellation) => await userService.BeExistingEmail(email, cancellation, user.Id))
            .WithMessage("Girilen email zaten kayıtlı!");
        
        // güncelleme istediğini atan kişi admin ise pass'ini güncelleme yetkisi olmadığı için kontrol etmiyoruz
        When(x => ClaimHelper.GetUserRole() != RoleEnum.Admin, () =>
        {
            RuleFor(x => x.Password1)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ValidationMessagesConst.RequiredMessage)
                .Matches(RegexConst.PasswordRegex)
                .WithMessage(ValidationMessagesConst.PasswordApprove);

            RuleFor(x => x.Password2)
                .NotEmpty()
                .WithMessage(ValidationMessagesConst.RequiredMessage);
        });
        
        RuleFor(x => x.Role)
            .IsInEnum()
            .WithMessage("Geçersiz rol seçildi.");
    }
}