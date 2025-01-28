using FluentValidation;
using MyBlogSite.Core.Constants;
using MyBlogSite.Core.Dtos.PostType;

namespace Base.Validator.PostType
{
    public class BlogTypeCreateDtoValidator : AbstractValidator<PostTypeCreateDto>
    {
        public BlogTypeCreateDtoValidator()
        {
            RuleFor(x => x.TypeName)
                .NotEmpty()
                .WithMessage(ValidationMessagesConst.RequiredMessage);
        }
    }
}