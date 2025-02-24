using FluentValidation;
using MyBlogSite.Business.Services.Services;
using MyBlogSite.Core.Constants;
using MyBlogSite.Core.Dtos.Post;

namespace Base.Validator.Post;

public class PostCreateDtoValidator : AbstractValidator<PostCreateDto>
{
    public PostCreateDtoValidator(PostTypeService postTypeService)
    {
        RuleFor(x => x.Title).NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage);
        
        RuleFor(x => x.Content).NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage);
        
        RuleFor(x => x.TypeId)
            .Cascade(CascadeMode.Stop)
            .NotEqual(Guid.Empty)
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .MustAsync(async (typeId, cancellation) => await postTypeService.BeExisting(typeId, cancellation))
            .WithMessage("Post kategorisi bulunamadı");
    }
}