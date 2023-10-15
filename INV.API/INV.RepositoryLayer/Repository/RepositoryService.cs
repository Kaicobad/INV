using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using INV.DomainLayer.Data;
using INV.DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace INV.RepositoryLayer.Repository
{
    public class RepositoryService<T> : IRepositoryService<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;
        private DbSet<T> entities;

        public RepositoryService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<T>();

        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task<T> Get(int id)
        {
            var data = await entities.SingleOrDefaultAsync(x => x.Id == id);
            return data;

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync(); 
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
