using INV.DomainLayer.DTOs.User;
using INV.ServiceLayer.Interfaces;
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

        public LoginController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public Task<ActionResult> Authenticate(UserDTO user) 
        {
            return null;
            //var dbUsers = _userService.GetAllUser()
        }
    }
}
