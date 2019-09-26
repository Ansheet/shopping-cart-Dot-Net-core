using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext _db = null;
        private DbSet<T> entities = null;
        public Repository(ApplicationDbContext _context)
        {
            _db = _context;
            entities = _db.Set<T>();
        }
        public IEnumerable<T> All()
        {
            return entities.ToList();
        }

        public void Create(T Entity)
        {
            _db.Entry(Entity).State = EntityState.Added;
        }

        public void Delete(int ID)
        {
            T existing = this.entities.Find(ID);

            this.entities.Remove(existing);
        }

        public void Edit(T Entity)
        {
            _db.Entry(Entity).State = EntityState.Modified;
        }


        public IEnumerable<T> GetAllEgarLoading(object ob, object obj)
        {
            return entities.Include(v => ob).Include(a => obj).ToList();
        }

        public T GetByID(int ID)
        {
            return entities.Find(ID);
        }

        public virtual async Task save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
