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
    public class RoleService : IRoleService
    {
        private readonly IRepositoryService<UserRole> _roleRepository;

        public RoleService(IRepositoryService<UserRole> repository)
        {
            _roleRepository = repository;
        }
        public void Delete(UserRole roles)
        {
            _roleRepository.Delete(roles);
            _roleRepository.SaveChanges();
        }

        public async Task<UserRole> Get(int id)
        {
            return await _roleRepository.Get(id);
        }

        public async Task<List<UserRole>> GetAlRoles()
        {
            return await _roleRepository.GetAll();
        }

        public void Insert(UserRole roles)
        {
            _roleRepository.Insert(roles);
            _roleRepository.SaveChanges();
        }

        public void Update(UserRole roles)
        {
            _roleRepository.Update(roles);
            _roleRepository.SaveChanges();
        }
    }
}
