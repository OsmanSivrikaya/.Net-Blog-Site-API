using System.Text;
using System.Text.RegularExpressions;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Business.Services.SlugServices.Interface;

namespace MyBlogSite.Business.Services.SlugServices;

public class SlagService(IBlogService blogService) : ISlugService
{
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
        while (await blogService.BeExistingSlug(slug))
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