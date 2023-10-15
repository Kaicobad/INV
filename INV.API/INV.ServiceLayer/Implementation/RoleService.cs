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
        private readonly IRepositoryService<RoleEntity> _repository;

        public RoleService(IRepositoryService<RoleEntity> repository)
        {
            _repository = repository;
        }
        public void Delete(RoleEntity roles)
        {
            _repository.Delete(roles);
            _repository.SaveChanges();
        }

        public async Task<RoleEntity> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<IEnumerable<RoleEntity>> GetAlRoles()
        {
            return await _repository.GetAll();
        }

        public void Insert(RoleEntity roles)
        {
            _repository.Insert(roles);
            _repository.SaveChanges();
        }

        public void Update(RoleEntity roles)
        {
            _repository.Update(roles);
            _repository.SaveChanges();
        }
    }
}
