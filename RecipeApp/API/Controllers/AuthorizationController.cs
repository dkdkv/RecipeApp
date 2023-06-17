using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RecipeApp.Application.Common;
using RecipeApp.Application.ViewModel;
using RecipeApp.Domain.Entities;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace RecipeApp.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthorizationController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._configuration = configuration;
        }

        [HttpPost("Token")]
        public async Task<IActionResult> CreateToken([FromBody] LoginModel login)
        {
            var user = await _userManager.FindByNameAsync(login.Username!);

            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password!))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                
                var claims = new List<Claim>
                {
                    new(JwtRegisteredClaimNames.Sub, user.Id!),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("LOL!23JWTAuthentication@777"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "https://localhost:44325",
                    audience: "https://localhost:44325",
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest("Invalid credentials");
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status409Conflict, new Response("Error", "User already exists!"));

            User user = new()
            {
                Email = model.Email,
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status409Conflict,
                    new Response("Error", "User creation failed! Please check user details and try again."));

            return Ok(new Response("Success", "User created successfully!"));
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status409Conflict, new Response("Error", "User already exists!"));

            User user = new()
            {
                Email = model.Email,
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status409Conflict,
                    new Response("Error", "User creation failed! Please check user details and try again."));

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }

            return Ok(new Response("Success", "User created successfully!"));
        }
    }
}