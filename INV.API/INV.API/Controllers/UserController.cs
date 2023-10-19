using AutoMapper;
using INV.API.DTO;
using INV.DomainLayer.DTOs.User;
using INV.DomainLayer.Models;
using INV.ServiceLayer.Implementation;
using INV.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Collections.Immutable;
using System.Data;
using System.Security.Cryptography;
using System.Text;

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
                //CreatePasswordHash(user.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
                
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
        //Helper
        private void CreatePasswordHash(string Password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password));
            }
        }
       
        [HttpGet("GetAll")]
        [Authorize]
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
