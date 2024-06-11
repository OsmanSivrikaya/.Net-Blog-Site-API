using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBlogSite.Common.Utilities;
using MyBlogSite.Data.Repository.IRepository;
using MyBlogSite.Dtos.User;
using MyBlogSite.Entity;
using MyBlogSite.Services.IServices;

namespace MyBlogSite.Services.Services
{
    public class UserService(IUserRepository _userRepository, IMapper _mapper) : IUserService
    {
        public async Task<UserViewDto> CreateAsync(UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            user.Password = HashHelper.ComputeSHA256Hash(user.Password);
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