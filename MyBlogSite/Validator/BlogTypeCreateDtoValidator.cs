using FluentValidation;
using MyBlogSite.Constants;
using MyBlogSite.Dtos.BlogType;

namespace MyBlogSite.Validator
{
    public class BlogTypeCreateDtoValidator : AbstractValidator<BlogTypeCreateDto>
    {
        public BlogTypeCreateDtoValidator()
        {
            RuleFor(x => x.TypeName)
                .NotNull().NotEmpty().WithMessage(ValidationMessagesConst.RequiredMessage)
                .Length(1, 255).WithMessage(ValidationMessagesConst.LengthMessage);
        }
    }
}