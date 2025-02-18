using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Business.Extensions;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Business.Services.SlugServices.Interface;
using MyBlogSite.Core.Dtos.ProducerDtos;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Core.Dtos.User;
using MyBlogSite.Core.Helpers;
using MyBlogSite.Core.Producers.Interface;
using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Business.Services.Services;

public class UserService(
    IUserRepository userRepository,
    IMapper mapper,
    ISlugService slugService,
    IEmailProducer emailProducer) : IUserService
{
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

    public UserUpdateDto Update(UserUpdateDto userUpdateDto)
    {
        var user = mapper.Map<User>(userUpdateDto);
        user = userRepository.Update(user);
        return userUpdateDto;
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

    public async Task<bool> BeExistingUsername(string? username, CancellationToken cancellationToken = default)
    {
        var result = !await userRepository.GetWhere(x => x.Username == username && x.IsActive)
            .AnyAsync(cancellationToken);
        return result;
    }

    public async Task<bool> BeExistingEmail(string? username, CancellationToken cancellationToken = default)
    {
        var result = !await userRepository.GetWhere(x => x.Username == username && x.IsActive)
            .AnyAsync(cancellationToken);
        return result;
    }
}