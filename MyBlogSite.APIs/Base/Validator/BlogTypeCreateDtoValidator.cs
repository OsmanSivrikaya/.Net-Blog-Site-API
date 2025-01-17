using FluentValidation;
using MyBlogSite.Core.Constants;
using MyBlogSite.Dtos.BlogType;

namespace Base.Validator
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