using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Business.Services.SlugServices.Interface;
using MyBlogSite.Core.Dtos.Post;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Core.Enums;
using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Business.Services.Services;

/// <summary>
/// PostService, blog gönderilerini oluşturma ve etiketlerle ilişkilendirme işlemlerini yönetir.
/// </summary>
public class PostService(
    IPostRepository postRepository,
    IMapper mapper,
    ITagService tagService,
    ISlugService slugService) : IPostService
{
    #region Methods
    
    /// <summary>
    /// Yeni bir blog gönderisi oluşturur ve etiketlerini ekler.
    /// </summary>
    /// <param name="request">Oluşturulacak gönderiye ait DTO nesnesi.</param>
    /// <returns>İşlem sonucunu belirten Result nesnesi.</returns>
    public async Task<Result> PostCreateAsync(PostCreateDto request)
    {
        // Post nesnesini DTO'dan Entity'ye map et
        var post = mapper.Map<Post>(request);
        post.Slug = await slugService.GenerateUniqueBlogSlugAsync(post.Title);

        // Post'a etiketleri ekle
        if (request.PostTags != null && request.PostTags.Any())
            post.PostTags = await CreatePostTagListAsync(request.PostTags, post.Id);

        // Post'u veritabanına ekle
        post = await postRepository.CreateAsync(post);
        
        return Result.Ok("Post has been created", post.Id);
    }

    public async Task<Result> PostImageAddedAsync()
    {
        return null;
    }

    #endregion
    
    #region Private Methods
    
    /// <summary>
    /// Gönderiye ait etiketleri oluşturur ve ilişkilendirir.
    /// </summary>
    /// <param name="postTags">Gönderiye eklenmek istenen etiketler.</param>
    /// <param name="postId">İlgili gönderinin benzersiz kimliği.</param>
    /// <returns>PostTag nesnelerinin listesini döner.</returns>
    private async Task<List<PostTag>> CreatePostTagListAsync(List<PostTagDto> postTags, Guid postId)
    {
        var postTagList = new List<PostTag>();
        #region Var olan etiketleri bağla

        // Var olan etiket ID'lerini al
        var tagIds = postTags.Select(x => x.TagId).Where(id => id.HasValue).Select(id => id.Value).ToList();
    
        // Veritabanında bulunan etiketleri çek
        var existingTags = await tagService
            .GetWhere(x => tagIds.Contains(x.Id))
            .ToListAsync();
    
        // Mevcut etiketleri PostTag nesnelerine ekleyerek listeye dahil et
        postTagList.AddRange(existingTags.Select(x => new PostTag
        {
            PostId = postId,
            TagId = x.Id,
        }));

        #endregion

        #region Daha önce reddedilmiş etiketleri tekrar aktif hale getir

        // Daha önce reddedilmiş ve yeniden eklenmek istenen etiketleri çek
        var rejectedTags = await tagService
            .GetWhere(x => x.TagStatus == TagStatus.Rejected && postTags.Select(t => t.Name).Contains(x.TagName))
            .ToListAsync();

        // Reddedilmiş etiketleri tekrar "Pending" durumuna getir ve listeye ekle
        foreach (var tag in rejectedTags)
        {
            tag.TagStatus = TagStatus.Pending;
            postTagList.Add(new PostTag
            {
                PostId = postId,
                TagId = tag.Id,
            });
        }

        #endregion

        #region Yeni etiketleri oluştur ve ekle

        // Yeni eklenmesi gereken etiketlerin isimlerini al
        var newTagNames = postTags
            .Where(x => x.TagId == null)
            .Select(x => x.Name)
            .Distinct()
            .ToList();
    
        // Mevcut etiket isimlerini listeye ekleyerek karşılaştırma yap
        var existingTagNames = existingTags.Select(t => t.TagName)
            .Union(rejectedTags.Select(t => t.TagName))
            .ToHashSet();
    
        // Sadece veritabanında olmayan etiketleri oluştur
        var newTags = newTagNames
            .Where(name => !existingTagNames.Contains(name)) 
            .Select(name => new Tag
            {
                Id = Guid.NewGuid(),
                TagName = name,
                TagStatus = TagStatus.Pending
            })
            .ToList();

        // Yeni etiketleri veritabanına ekleyip, PostTag ilişkisini oluştur
        if (postTagList.Any())
        {
            await tagService.CreateRangeAsync(newTags);
            postTagList.AddRange(newTags.Select(x => new PostTag
            {
                PostId = postId,
                TagId = x.Id
            }));
        }

        #endregion

        return postTagList;
    }
    
    #endregion
}
