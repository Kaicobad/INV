using INV.DomainLayer.DTOs.User;
using INV.DomainLayer.Models;

namespace INV.API.DTO
{
    public class ResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class UserResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Users { get; set; }
    }
}
