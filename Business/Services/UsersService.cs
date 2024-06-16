using System.Collections.Generic;
using System.Threading.Tasks;
using Elpis.Business.Services.Interfaces;
using Elpis.Data.Repositories.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Elpis.Data;

namespace Elpis.Business.Services
{
	public class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersService(IUsersRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _userRepository.GetAllUsers();
        }
        public Task DeleteAsync(User user)
        {
            return _userRepository.DeleteAsync(user);
        }
        public async Task<User?> GetUserByIdAsync(string id)
        {
            return await _userRepository.FindAsync(id);
        }

        public async Task<User> AddUser(User user)
        {
            user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = user.Email,
                UserName = user.Email,
                NormalizedUserName = user.Email.ToUpper(),
                NormalizedEmail = user.Email.ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "ElP1s");
            return await _userRepository.AddAsync(user);
        }

        public async Task<string> GetCurrentUserId()
        {
            if (_httpContextAccessor.HttpContext.User.Identity != null)
            {
                var claimsIdentity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;
                var nameIdentifierClaim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                var userId = nameIdentifierClaim != null ? nameIdentifierClaim.Value : "";
                return userId;
            }
            return null;
        }

        public async Task<User?> GetUserDataByUserId(string userId)
        {
            var userInfo = await _userRepository.FindAsync(userId);

            return userInfo == null ? null : userInfo;
        }
    }
}
