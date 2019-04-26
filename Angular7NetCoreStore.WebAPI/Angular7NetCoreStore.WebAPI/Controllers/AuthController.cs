using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Angular7NetCoreStore.Application.Dtos;
using Angular7NetCoreStore.Application.Interfaces;
using Angular7NetCoreStore.Infra.CrossCutting.Identity.Models;
using Angular7NetCoreStore.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Angular7NetCoreStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICustomerAppService _customerAppService;

        public AuthController(IOptions<AppSettings> appSettings,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ICustomerAppService customerAppService)
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
            _customerAppService = customerAppService;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.AuthenticationSettings.SecretKey));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _appSettings.AuthenticationSettings.Issuer,
                    audience: _appSettings.AuthenticationSettings.Audience,
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                var identityUser = await _userManager.FindByEmailAsync(user.UserName);

                return Ok(new { Token = tokenString, identityUser.CustomerId });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(AddCustomerDto addCustomerDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var commandResult = await _customerAppService.AddCustomerAsync(addCustomerDto);
                    if (commandResult.Success)
                    {
                        return Ok(commandResult);
                    }

                    return BadRequest(commandResult);
                }
            }
            catch (System.Exception exception)
            {

                throw;
            }

            return Ok();
        }
    }
}