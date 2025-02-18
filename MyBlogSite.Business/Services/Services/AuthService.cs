using AutoMapper;
using Base.Exceptions;
using Microsoft.Extensions.Configuration;
using MyBlogSite.Business.Services.IServices;
using MyBlogSite.Core.Dtos;
using MyBlogSite.Core.Dtos.Auth;
using MyBlogSite.Core.Dtos.ProducerDtos;
using MyBlogSite.Core.Dtos.Response;
using MyBlogSite.Core.Dtos.Token;
using MyBlogSite.Core.Dtos.User;
using MyBlogSite.Core.Helpers;
using MyBlogSite.Core.Producers.Interface;
using MyBlogSite.Dtos.Token;

namespace MyBlogSite.Business.Services.Services
{
    public class AuthService(
        ITokenService tokenService,
        IUserService userService,
        IEmailProducer emailProducer,
        IConfiguration configuration,
        IMapper mapper) : IAuthService
    {
        public async Task<UserLoginResponseDto> LoginUserAsycn(UserLoginRequestDto request)
        {
            var hashPassword = HashHelper.ComputeSha256Hash(request.Password);
            var user = await userService.GetFirstAsync(
                x => x.Email == request.Email && x.Password == hashPassword);

            if (user is null)
            {
                throw new NotFoundException("Kullanıcı bulunamadı!");
            }

            var generatedTokenInformation =
                await tokenService.GenerateToken(new GenerateTokenRequestDto
                {
                    Username = request.Email,
                    UserId = user.Id,
                    Role = user.Role
                });
            return new UserLoginResponseDto
            {
                AuthenticateResult = true,
                AuthToken = generatedTokenInformation.Token,
                AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate
            };
            return null;
        }

        public async Task<Result> ResetPassword(UserResetPasswordRequestDto passwordRequest)
        {
            var user = await userService.GetFirstAsync(x => x.Email == passwordRequest.Email);

            if (user == null)
            {
                return Result.Ok("Şifre sıfırlama maili gönderildi!");
            }

            var time = DateTime.UtcNow.AddHours(1);
            
            var resetPasswordToken = tokenService.Encrypt(new ResetPasswordTokenDto
            {
                Email = user.Email,
                Date = time
            });

            // TODO : client yapılına url düzeltilicek
            var url = configuration.GetSection("URLS:ResetPasswordUrl").Value + resetPasswordToken;
            var userFullName = $"{user.Name} {user.Surname}";

            await emailProducer.SendEmailQueueAsync(new EmailMessageDto
            {
                Body = MailTemplateHelper.PasswordResetMessage(userFullName, url),
                Subject = "Şifremi Unuttum",
                ToEmails = [user.Email]
            });
            
            return Result.Ok();
        }

        public async Task<Result> ApproveResetPassword(UserResetPasswordApproveRequestDto request)
        {
            var token = tokenService.Decrypt<ResetPasswordTokenDto>(request.Token);

            if (token != null)
            {
                if (token.Date < DateTime.UtcNow)
                    throw new BadRequestException("Şifre sıfırlama için gerekli olan süre dolmuştur");
                
                var user = await userService.GetFirstAsync(x => x.Email == request.Email);
                user.Password =HashHelper.ComputeSha256Hash(request.Pass1);
            }
            
            return Result.Ok("Şifre güncelleme işlemi başarılı!");
        }
    }
}