using Base.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogSite.Business.Services.FileStorageManagerServices.Interface;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Core.Enums;

namespace FileStorage.Controllers;

[ApiVersion("1")]
[Route("file-storage")]
[Authorize]
public class FileStorageController(IFileStorageManager fileStorageManager) : BaseController
{
    [HttpPost("file-upload")]
    public async Task<Result> FileUpload(IFormFile file, string fileName) =>
        Result.Ok(await fileStorageManager.UploadFileAsync(file, fileName, FolderEnum.Temporary));
}