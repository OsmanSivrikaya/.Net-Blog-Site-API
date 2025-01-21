using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Business.Services.SlugServices.Interface;
using MyBlogSite.Core.Dtos;
using MyBlogSite.Core.Dtos.User;
using MyBlogSite.Core.Helpers;
using MyBlogSite.Core.Producers.Interface;
using MyBlogSite.Dal;
using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Business.Services.Services;

public class UserService(IUserRepository userRepository, IMapper mapper, ISlugService slugService, IEmailProducer emailProducer) : IUserService
{
    public async Task<UserViewDto> CreateAsync(UserCreateDto userCreateDto)
    {
        var user = mapper.Map<User>(userCreateDto);
        user.Password = HashHelper.ComputeSha256Hash(user.Password);
        user.Blog.Slug = await slugService.GenerateUniqueBlogSlugAsync(userCreateDto.Blog.BlogName);

        user = await userRepository.CreateAsync(user);
        
        await emailProducer.SendEmailQueueAsync(new EmailMessageDto
        {
            Subject = "Hoş Geldiniz!",
            Body = MailTemplateHelper.WelcomeMessage(user.Name + " " + user.Surname.ToUpper()),
            ToEmails = [user.Email]
        });
        
        return mapper.Map<UserViewDto>(user);
    }
    
    public async Task<List<UserViewDto>> GetAllUsers()
    {
        var users = await userRepository.GetAll().ToListAsync();
        return mapper.Map<List<UserViewDto>>(users);
    }

    public async Task<User?> GetFirstAsync(Expression<Func<User, bool>> method)
    {
        return await userRepository.GetFirstAsync(method);
    }
    
    public async Task<bool> BeExistingUsername(string? username, CancellationToken cancellationToken = default)
    {
        var result = !await userRepository.GetWhere(x => x.Username == username && x.IsActive).AnyAsync(cancellationToken);
        return result;
    }

    public async Task<bool> BeExistingEmail(string? username, CancellationToken cancellationToken = default)
    {
        var result = !await userRepository.GetWhere(x => x.Username == username && x.IsActive).AnyAsync(cancellationToken);
        return result;
    }
}