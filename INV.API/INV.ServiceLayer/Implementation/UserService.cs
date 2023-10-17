using INV.API.DTO;
using INV.DomainLayer.DTOs.User;
using INV.DomainLayer.Models;
using INV.RepositoryLayer.Repository;
using INV.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.ServiceLayer.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepositoryService<UserModel> _userRepository;

        public UserService(IRepositoryService<UserModel> repository)
        {
            _userRepository = repository;
        }

        public void AddUser(UserModel user)
        {
            _userRepository.Insert(user);
            _userRepository.SaveChanges();
        }

        public Task<List<UserModel>> GetAllUser()
        {
            var users = _userRepository.GetAll();
            return users;
        }
    }
}
