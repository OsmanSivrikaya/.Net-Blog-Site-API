using FluentValidation;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Constants;
using MyBlogSite.Core.Dtos.Comment;

namespace Base.Validator.Comment;

public class PostCommentCreateDtoValidator : AbstractValidator<PostCommentCreateDto>
{
    public PostCommentCreateDtoValidator(IPostService postService, IPostCommentService postCommentService)
    {
        RuleFor(x => x.PostId)
            .Cascade(CascadeMode.Stop)
            .NotEqual(Guid.Empty)
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .MustAsync(async (postId, cancellation) => 
                postId == null || await postService.BeExistingPostAsync(postId.Value, cancellation))
            .WithMessage("Post bulunamadı");
        
        RuleFor(x => x.ParentCommentId)
            .Cascade(CascadeMode.Stop)
            .NotEqual(Guid.Empty)
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .MustAsync(async (parentCommentId, cancellation) => 
                parentCommentId == null || await postCommentService.BeExist(parentCommentId.Value, cancellation))
            .WithMessage("Yorum bulunamadı");
        
        RuleFor(x => x.Content)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage(ValidationMessagesConst.RequiredMessage)
            .WithMessage("Yorum boş bırakılamaz!");
    }
}