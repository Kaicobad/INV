using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost("AddUser")]
        public Task<ResponseDTO> AddUser(UserDTO user)
        {
            try
            {
                var userData = _mapper.Map<UserModel>(user);
                _userService.AddUser(userData);
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
                var users =  await _userService.GetAllUser();

                //var mp = users.Select(user => _mapper.Map<UserDTO>(user)).ToList();
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
