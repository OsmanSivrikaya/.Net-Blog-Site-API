namespace MyBlogSite.Business.Services.SlugServices.Interface;

public interface ISlugService
{
    Task<string> GenerateUniqueBlogSlugAsync(string? input);
    Task<string> GenerateUniquePostTypeSlugAsync(string? input);
}