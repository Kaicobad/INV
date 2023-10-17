using AutoMapper;
using INV.API.DTO.Role;
using INV.DomainLayer.DTOs.User;
using INV.DomainLayer.Models;

namespace INV.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserModel, UserDTO>();
            CreateMap<UserRole, RoleDTO>();
        }
    }
}
