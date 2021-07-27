using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using samsung.sedac.alligatormanagerproject.Api.DTO;
using samsung.sedac.alligatormanagerproject.Api.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace samsung.sedac.alligatormanagerproject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /*Neste caso vamos precisar instalar também o Automapper*/
        private readonly IConfiguration _config;
        private readonly UserManager<Users> _userManger;
        private readonly SignInManager<Users> _signInManager;
        private readonly IMapper _mapper;

        public UserController(IConfiguration config, UserManager<Users> userManger,
                                                     SignInManager<Users> signInManager,
                                                     IMapper mapper)
        {
            _config = config;
            _userManger = userManger;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new UserDto());
        }

            

        // POST api/<UserController>
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDto model)
        {
            try
            {
                var user = await _userManger.FindByIdAsync(model.UserName);
                if (user == null)
                {
                    user = new Users
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserName = model.UserName,
                        Email = model.Email

                    };

                    var result = await _userManger.CreateAsync(
                        user, model.Password);

                    if (result.Succeeded)
                    {
                        //var token = await _userManger.GenerateEmailConfirmationTokenAsync(user);
                        var appUser = await _userManger.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == user.UserName.ToUpper());
                        var token = GenerateJWTToken(appUser).Result;
                        //var confirmationEmail = Url.Action("ComfirmEmailAddress", "Home",
                        //    new { token = token, email = user.Email }, Request.Scheme);

                        //System.IO.File.WriteAllText("confirmationEmail.text", confirmationEmail);

                        return Ok(token);
                    }
                   
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error {ex.Message }");
            }
               
            
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDto userLogin)
        {
            try
            {
                var user = await _userManger.FindByIdAsync(userLogin.UserName);
                var result = await _signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);
                if (result.Succeeded)
                {
                    var appUser = await _userManger.Users
                        .FirstOrDefaultAsync(u => u.NormalizedUserName == user.UserName.ToUpper());

                    var userToReturn = _mapper.Map<UserDto>(appUser);
                   
                    return Ok(new
                    {
                        token = GenerateJWTToken(appUser).Result,
                        user = appUser
                    });
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error {ex.Message }");
            }
        }
        /// <summary>
        /// Token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task<string> GenerateJWTToken(Users user)
        {
            var claims = new List<Claim>
           {
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new Claim(ClaimTypes.Name,user.UserName)
           };

            var roles = await _userManger.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds

            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var toker = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(toker);
        }
      
    }
}
