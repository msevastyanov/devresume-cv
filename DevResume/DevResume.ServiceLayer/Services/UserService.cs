using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DevResume.Domain.Entities;
using DevResume.Domain.Models;
using DevResume.Domain.ViewModels;

namespace DevResume.ServiceLayer.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IUserClaimsProvider _claimsProvider;

        public UserService(UserManager<ApplicationUser> userManager,
            IUserClaimsProvider claimsProvider)
        {
            _userManager = userManager;
            _claimsProvider = claimsProvider;
        }

        public async Task<RequestResult<ApplicationUser>> CreateAccount(CreateUser model)
        {
            var existingUser = await _userManager.FindByNameAsync(model.Username);
            if (existingUser != null)
                return RequestResult<ApplicationUser>.Failed("Пользователь с таким именем уже существует");

            var user = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                PhoneNumber = null,
                PhoneNumberConfirmed = true,
                Email = null,
                EmailConfirmed = true,
                TwoFactorEnabled = false,
                FirstNameEn = model.FirstNameEn,
                LastNameEn = model.LastNameEn,
                FirstNameRus = model.FirstNameRus,
                MiddleNameRus = model.MiddleNameRus,
                LastNameRus = model.LastNameRus,
                DateOfBirth = model.DateOfBirth
            };

            var creationResult = await _userManager.CreateAsync(user, model.Password);
            if (!creationResult.Succeeded)
                return RequestResult<ApplicationUser>.Failed(creationResult.Errors.First().Description);

            var claims = _claimsProvider.GenerateClaims(user);

            var addClaimsResult = await _userManager.AddClaimsAsync(user, claims);

            return !addClaimsResult.Succeeded
                ? RequestResult<ApplicationUser>.Failed(addClaimsResult.Errors.First().Description)
                : RequestResult<ApplicationUser>.Success(user);
        }
    }
}