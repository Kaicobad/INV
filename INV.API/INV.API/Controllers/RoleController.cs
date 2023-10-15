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

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("AddRole")]
        public Task<ResponseDTO> AddRole(RoleEntity roleDTO)
        {
            try
            {
                _roleService.Insert(roleDTO);
                return Task.FromResult(new ResponseDTO
                {
                    Success = true,
                    Message = "Data inserted"
                }); ;
            }
            catch (Exception ex)
            {

                return Task.FromResult(new ResponseDTO
                {
                    Success = true,
                    Message = ex.Message
                }); ;
            }
        }

    }
}
