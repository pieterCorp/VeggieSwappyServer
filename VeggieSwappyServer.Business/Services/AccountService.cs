using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VeggieSwappyServer.Business.Dto;
using VeggieSwappyServer.Data.Entities;
using VeggieSwappyServer.Data.Repositories;

namespace VeggieSwappyServer.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepo _userRepo;
        private readonly ITokenService _tokenService;

        public AccountService(IUserRepo userRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }

        public async Task<UserTokenDto> LoginAsync(string eMail, string password)
        {
            User user = await _userRepo.GetUserByEmailAsync(eMail);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid Email");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            if (!hash.SequenceEqual(user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid password");
            }

            return CreateUserDTO(user);
        }

        public async Task<UserTokenDto> RegisterAsync(RegisterDto dto)
        {
            if (await _userRepo.UserExistsAsync(dto.Email))
            {
                throw new UnauthorizedAccessException("Email already exists, please try again or login");
            }
            using var hmac = new HMACSHA512();

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                PasswordSalt = hmac.Key,
                ImageUrl = dto.ImageUrl,
            };

            await _userRepo.AddEntityAsync(user);

            return CreateUserDTO(user);
        }

        private UserTokenDto CreateUserDTO(User user)
        {
            return new UserTokenDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                Token = _tokenService.CreateToken(user),
                ImageUrl = user.ImageUrl
            };
        }
    }
}
