using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Business.Services.SlugServices.Interface;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Business.Services.SlugServices;

public class SlagService(IBlogRepository blogRepository, IPostTypeRepository postTypeRepository) : ISlugService
{
    /// <summary>
    /// Post type için uniq bir slug oluşturur.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<string> GenerateUniquePostTypeSlugAsync(string? input)
    {
        var baseSlug = GenerateSlug(input);
        var slug = baseSlug;
        var counter = 1;

        // Benzersizlik kontrolü
        while (await postTypeRepository.GetWhere(x => x.Slug == slug).AnyAsync())
        {
            slug = $"{baseSlug}-{counter}";
            counter++;
        }

        return slug;
    }

    /// <summary>
    /// Blog için uniq bir slug oluşturur
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<string> GenerateUniqueBlogSlugAsync(string? input)
    {
        var baseSlug = GenerateSlug(input);
        var slug = baseSlug;
        var counter = 1;

        // Benzersizlik kontrolü
        while (await blogRepository.GetWhere(x => x.Slug == slug).AnyAsync())
        {
            slug = $"{baseSlug}-{counter}";
            counter++;
        }

        return slug;
    }

    private static string GenerateSlug(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        // Temel slug'ı oluştur
        var slug = input.ToLowerInvariant();
        slug = ReplaceTurkishCharacters(slug);
        slug = Regex.Replace(slug, @"[^a-z0-9\s-]", string.Empty);
        slug = Regex.Replace(slug, @"\s+", "-").Trim('-');
        slug = Regex.Replace(slug, @"-+", "-");

        return slug;
    }

    private static string ReplaceTurkishCharacters(string text)
    {
        var replacements = new Dictionary<char, char>
        {
            { 'ç', 'c' }, { 'ğ', 'g' }, { 'ı', 'i' }, { 'ö', 'o' }, { 'ş', 's' }, { 'ü', 'u' },
            { 'Ç', 'C' }, { 'Ğ', 'G' }, { 'İ', 'I' }, { 'Ö', 'O' }, { 'Ş', 'S' }, { 'Ü', 'U' }
        };

        var stringBuilder = new StringBuilder(text.Length);
        foreach (var character in text)
        {
            stringBuilder.Append(replacements.TryGetValue(character, out var replacement) ? replacement : character);
        }

        return stringBuilder.ToString();
    }
}