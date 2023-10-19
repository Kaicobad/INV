using INV.DomainLayer.DTOs.Login;
using INV.DomainLayer.DTOs.User;
using INV.ServiceLayer.Interfaces;
using INV.ServiceLayer.JwtService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IJwtTokenService _tokenService;

        public LoginController(IUserService userService, IRoleService roleService,IJwtTokenService tokenService)
        {
            _userService = userService;
            _roleService = roleService;
            _tokenService = tokenService;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> Authenticate(LoginDTO user) 
        {
            var JWTtoken = string.Empty;
            var dbUsers = await _userService.GetUserByName(user.Name);
            var Roles = await _roleService.GetAlRoles();
            if (dbUsers != null) 
            {
                JWTtoken = _tokenService.GetJwtToken(dbUsers, Roles);
            }
            return Ok(new
            {
                AccessToken = JWTtoken
            });
        }
    }
}
