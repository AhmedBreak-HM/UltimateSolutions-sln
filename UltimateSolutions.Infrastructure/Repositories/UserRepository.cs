using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UltimateSolutions.Application.Commands.User.LogInUser;
using UltimateSolutions.Application.Commands.User.SignUpUser;
using UltimateSolutions.Application.Contracts;
using UltimateSolutions.Application.Queries.User.GetUserByName;
using UltimateSolutions.Domain.Models;

namespace UltimateSolutions.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserApplication> _signInManager;
        private readonly UserManager<UserApplication> _userManager;

        public UserRepository(UserManager<UserApplication> userManager,
            IConfiguration configuration, IMapper mapper, SignInManager<UserApplication> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<UserForReturnDto> GetUserByName(string name)
        {
            var user = await _userManager.FindByNameAsync(name);

            return _mapper.Map<UserForReturnDto>(user);
        }

        public async Task<LogInUserForReturnDto> LogIn(LogInUserCommand logInUserCommand, CancellationToken cancellationToken)
        {
            var userFromRepo = await _userManager.FindByNameAsync(logInUserCommand.UserName);

            var result = await _signInManager.CheckPasswordSignInAsync(userFromRepo, logInUserCommand.Password, false);

            if (result.Succeeded)
            {
                var userApp = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == logInUserCommand.UserName.ToUpper(), cancellationToken);

                var userToReturn = _mapper.Map<LogInUserForReturnDto>(userApp);
                userToReturn.Token = GenerateJwtToken(userApp);

                return userToReturn;
            }
            return null;
        }

        public async Task<IdentityResult> SignUp(SignUpUserCommand signUpUserCommand)
        {
            var userForCreate = _mapper.Map<UserApplication>(signUpUserCommand);
            var result = await _userManager.CreateAsync(userForCreate, signUpUserCommand.Password);

            if (!result.Succeeded) return null;

            // Create Role Member For User
            var user = await _userManager.FindByNameAsync(signUpUserCommand.UserName);
            var resultRoleCreate = await _userManager.AddToRolesAsync(user, new[] { "Member" });
            if (!resultRoleCreate.Succeeded) return null;
            return result;
        }

        private string GenerateJwtToken(UserApplication user)
        {
            var claims = GetClaims(user);

            // genreated key and convert to bytes
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:TokenKey").Value));

            // genreated Credentials by hashing key
            var Creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            // genreate Token Descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = Creds
            };

            // genreate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private List<Claim> GetClaims(UserApplication user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
            };

            var roles = GetUserRolesAsync(user);
            foreach (var role in roles.Result)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private async Task<IList<string>> GetUserRolesAsync(UserApplication user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }
    }
}