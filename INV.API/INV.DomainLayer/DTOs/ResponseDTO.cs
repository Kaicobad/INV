using INV.DomainLayer.DTOs.User;
using INV.DomainLayer.Models;

namespace INV.API.DTO
{
    public class ResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class UserResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public object Users { get; set; } = string.Empty;
    }
}
