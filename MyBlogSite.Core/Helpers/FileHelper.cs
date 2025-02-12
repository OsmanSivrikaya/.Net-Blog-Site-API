using Microsoft.AspNetCore.Http;

public static class FileHelper
{
    private static readonly Dictionary<string, string> MimeTypes = new()
    {
        { ".txt", "text/plain" },
        { ".pdf", "application/pdf" },
        { ".doc", "application/msword" },
        { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
        { ".xls", "application/vnd.ms-excel" },
        { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
        { ".png", "image/png" },
        { ".jpg", "image/jpeg" },
        { ".jpeg", "image/jpeg" },
        { ".gif", "image/gif" },
        { ".csv", "text/csv" },
        { ".zip", "application/zip" },
        { ".rar", "application/x-rar-compressed" }
    };

    public static string GetContentType(IFormFile file)
    {
        if (file == null)
        {
            throw new ArgumentNullException(nameof(file), "File cannot be null.");
        }

        // Eğer ContentType zaten ayarlanmışsa onu döndür.
        if (!string.IsNullOrEmpty(file.ContentType))
        {
            return file.ContentType;
        }

        // Uzantıya göre ContentType belirle.
        var extension = Path.GetExtension(file.FileName)?.ToLowerInvariant();
        if (extension != null && MimeTypes.TryGetValue(extension, out var mimeType))
        {
            return mimeType;
        }

        // Tanımlı değilse varsayılan bir ContentType döndür.
        return "application/octet-stream";
    }
}
