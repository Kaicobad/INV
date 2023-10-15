using INV.API.DTO;
using INV.DomainLayer.DTOs.User;
using INV.DomainLayer.Models;
using INV.ServiceLayer.Implementation;
using INV.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Data;

namespace INV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("AddUser")]
        public Task<ResponseDTO> AddUser(UserModel user)
        {
            try
            {
                _userService.AddUser(user);
                return Task.FromResult(new ResponseDTO
                {
                    Success = true,
                    Message = "Data inserted"
                });

            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResponseDTO
                {
                    Success = true,
                    Message = ex.GetBaseException().Message
                });
            }
        }
        [HttpGet("GetAll")]
        public async Task<UserResponseDto> AllUsers()
        {
            try
            {
                var users = Task.FromResult( await _userService.GetAllUser());
                //var t = await Task.FromResult(users);
                return new UserResponseDto
                {
                    Success = true,
                    Message = "All Users",
                    Users = users 
                };
            }
            catch (Exception ex)
            {
                return new UserResponseDto
                {
                    Success = false,
                    Message = ex.InnerException?.Message,
                    Users = null
                };
            }
        }
    }
}
