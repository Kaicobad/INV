using AutoMapper;
using INV.API.DTO;
using INV.DomainLayer.Models;
using INV.ServiceLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpPost("AddRole")]
        public Task<ResponseDTO> AddRole(UserRole role)
        {
            try
            {
                _roleService.Insert(role);
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

    }
}
