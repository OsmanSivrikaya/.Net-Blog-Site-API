using FluentValidation;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Constants;
using MyBlogSite.Core.Dtos.User;

namespace Base.Validator.User;

public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
{
    public UserCreateDtoValidator(IUserService userService, IBlogService blogService)
    {
        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .Length(1, 100)
            .WithMessage(ValidationMessagesConst.LengthMessage);
        
        RuleFor(x => x.Surname)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .Length(1, 100)
            .WithMessage(ValidationMessagesConst.LengthMessage);

        RuleFor(x => x.Username)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .Length(1, 100)
            .WithMessage(ValidationMessagesConst.LengthMessage)
            .MustAsync(async (username, cancellation) => await userService.BeExistingUsername(username, cancellation))
            .WithMessage("Girilen kullanıcı adı kullanılıyor!");

        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .Length(1, 200)
            .WithMessage(ValidationMessagesConst.LengthMessage)
            .MustAsync(async (email, cancellation) => await userService.BeExistingEmail(email, cancellation))
            .WithMessage("Girilen email zaten kayıtlı!");

        RuleFor(x => x.Password)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .Length(1, 300)
            .WithMessage(ValidationMessagesConst.LengthMessage);

        RuleFor(x => x.IsActive)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage(ValidationMessagesConst.RequiredMessage);
        
        RuleFor(x => x.Blog)
            .SetValidator(new CreateBlogDtoValidator(blogService));
    }
}

public class CreateBlogDtoValidator : AbstractValidator<CreateBlogDto>
{
    public CreateBlogDtoValidator(IBlogService blogService)
    {
        RuleFor(x => x.BlogName)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .Length(1, 150)
            .WithMessage(ValidationMessagesConst.LengthMessage)
            .MustAsync(async (blogName, cancellation) => await blogService.BeExistingBlogName(blogName,cancellation))
            .WithMessage("Girilen blog adı kullanılmaktadır!");

        RuleFor(x => x.Description)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .Length(1, 4000)
            .WithMessage(ValidationMessagesConst.LengthMessage);
    }
}