using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Business.Extensions;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Business.Services.SlugServices.Interface;
using MyBlogSite.Core.Dtos.Admin.User;
using MyBlogSite.Core.Dtos.ProducerDtos;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Core.Dtos.User;
using MyBlogSite.Core.Enums;
using MyBlogSite.Core.Helpers;
using MyBlogSite.Core.Producers.Interface;
using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Business.Services.Services;

public class UserService(
    IUserRepository userRepository,
    IMapper mapper,
    ISlugService slugService,
    IEmailProducer emailProducer,
    IBlogService blogService) : IUserService
{
    public async Task<Result> SetUserActivationStatusAsync(bool isActive, Guid userId)
    {
        var user = await userRepository.GetByIdAsync(userId);
        if (user is null)
            return Result.NotFound(false);

        var blog = await blogService.FirstOrDefaultAsync(x => x.FounderUserId == userId);
        if (isActive == false && blog is not null)
            return Result.BadRequest("Kurucu kullanıcı silinemez. Lütfen önce kuruculuk yetkisini kaldırın.", false);

        user.IsActive = isActive;
        return Result.Ok("İşlem gerçekleştirildi.", true);
    }

    public async Task<Result> GetUsersForAdminPageAsync(Guid userId)
    {
        var user = await userRepository.GetByIdAsync(userId);
        if (user is null)
            return Result.NotFound();
        return Result.Ok(mapper.Map<UsersForAdminResponseDto>(user));
    }

    public async Task<Result> SetUserBanStatusAsync(Guid userId, bool isBan)
    {
        var bannedUser = await userRepository.GetByIdAsync(userId);
        if (bannedUser is null)
            return Result.NotFound(false);
        
        // blogdaki diğer kullanıcılar
        var blogUser = await userRepository
            .GetWhere(x => x.BlogId == bannedUser.BlogId && x.Id != bannedUser.Id)
            .FirstOrDefaultAsync();

        var blog = await blogService.FirstOrDefaultAsync(x => x.FounderUserId == userId);
        if (blog is not null)
        {
            if (blogUser is not null) // Eğer blogda başka kullanıcı varsa kurucu rolü devrediliyor
            {
                blog.FounderUserId = blogUser.Id;
                blogUser.Role = bannedUser.Role; // Yeni kurucu, admin olarak atanıyor
            }
            else // Blogda başka kullanıcı yoksa blog banlanıyor
            {
                blog.IsBanned = isBan;
            }
        }
        bannedUser.IsBanned = isBan;
        
        return Result.Ok("İşlem gerçekleştirildi.", true);
    }

    public async Task<Result> RemoveUserFromBlogRoleAsync(Guid userId)
    {
        var user = await userRepository.GetByIdAsync(userId);
        if (user is null)
            return Result.NotFound("Kullanıcı bulunamadı.");

        if (user.BlogId == null)
            return Result.BadRequest("Kullanıcı zaten blog yazarı değil.");

        var blog = await blogService.FirstOrDefaultAsync(x => x.FounderUserId == user.Id);
        if (blog is not null)
            blog.FounderUserId = null;
        user.BlogId = null;

        return Result.Ok("Kullanıcı blog yazarlığından kaldırıldı.");
    }

    public Result Update(UserUpdateDto userUpdateDto)
    {
        var user = mapper.Map<User>(userUpdateDto);

        var userRole = ClaimHelper.GetUserRole();

        if (userRole != RoleEnum.Admin)
            user.Password = HashHelper.ComputeSha256Hash(userUpdateDto.Password1);

        user = userRepository.Update(user);

        return Result.Ok();
    }

    public async Task<UserViewDto> RegisterUserAsync(UserRegisterDto userRegisterDto)
    {
        var user = mapper.Map<User>(userRegisterDto);
        user.Password = HashHelper.ComputeSha256Hash(user.Password);
        user.IsActive = true;

        if (user.Blog != null)
            user.Blog.Slug = await slugService.GenerateUniqueBlogSlugAsync(userRegisterDto.Blog?.BlogName);

        user = await userRepository.CreateAsync(user);

        await emailProducer.SendEmailQueueAsync(new EmailMessageDto
        {
            Subject = "Hoş Geldiniz!",
            Body = MailTemplateHelper.WelcomeMessage(user.Name + " " + user.Surname.ToUpper()),
            ToEmails = [user.Email]
        });

        return mapper.Map<UserViewDto>(user);
    }

    public async Task<PaginationResult<UserViewDto>> GetAllUsersPagination(int pageNumber, int pageSize)
    {
        var users = await userRepository
            .GetAll()
            .ProjectTo<UserViewDto>(mapper.ConfigurationProvider)
            .ToPaginationAsync(pageNumber, pageSize);
        return users;
    }

    public async Task<List<Guid>> GetAllUserByBlogIdAsync(Guid blogId)
    {
        return await userRepository
            .GetWhere(x => x.BlogId == blogId && x.IsActive)
            .Select(x => x.Id)
            .ToListAsync();
    }

    public async Task<User?> GetFirstAsync(Expression<Func<User, bool>> method)
    {
        return await userRepository.GetFirstAsync(method);
    }

    public async Task<bool> BeExisting(Guid userId, CancellationToken cancellationToken = default)
    {
        var result = !await userRepository.GetWhere(x => x.Id == userId && x.IsActive)
            .AnyAsync(cancellationToken);
        return result;
    }

    public async Task<bool> BeExistingUsername(string? username, CancellationToken cancellationToken = default)
    {
        var result = !await userRepository.GetWhere(x => x.Username == username && x.IsActive)
            .AnyAsync(cancellationToken);
        return result;
    }

    public async Task<bool> BeExistingEmail(string? mail, CancellationToken cancellationToken = default,
        Guid? userId = null)
    {
        var query = userRepository.GetWhere(x => x.Email == mail && x.IsActive);
        if (userId.HasValue)
        {
            query = query.Where(x => x.Id != userId.Value);
        }

        var result = !await query.AnyAsync(cancellationToken);
        return result;
    }
}