using FluentValidation;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Constants;
using MyBlogSite.Core.Dtos.Comment;

namespace Base.Validator.Comment;

public class PostCommentUpdateDtoValidator : AbstractValidator<PostCommentUpdateDto>
{
    public PostCommentUpdateDtoValidator(IPostCommentService postCommentService)
    {
        RuleFor(x => x.Id)
            .Cascade(CascadeMode.Stop)
            .NotEqual(Guid.Empty)
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .MustAsync(async (id, cancellation) => await postCommentService.BeExist(id, cancellation))
            .WithMessage("Yorum bulunamadı!");
        
        RuleFor(x => x.Content)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .WithMessage("Yorum boş bırakılamaz!");
    }
}