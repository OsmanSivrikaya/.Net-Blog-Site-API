using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos.User;
using MyBlogSite.Core.Utilities;
using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Business.Services.Services
{
    public class UserService(IUserRepository _userRepository, IMapper _mapper) : IUserService
    {
        public async Task<UserViewDto> CreateAsync(UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            user.Password = HashHelper.ComputeSha256Hash(user.Password);
            return _mapper.Map<UserViewDto>(await _userRepository.CreateAsync(user));
        }

        public async Task<List<UserViewDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAll().ToListAsync();
            return _mapper.Map<List<UserViewDto>>(users);
        }

        public async Task<User?> GetFirstAsync(Expression<Func<User, bool>> method)
        {
            return await _userRepository.GetFirstAsync(method);
        }
    }
}