using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП9
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private BankContext _bc;
        private DbSet<T> _entity;

        public Repository(BankContext bc)
        {
            _bc = bc;
            _entity = bc.Set<T>();
        }

        public void Add(T entity)
        {
            _entity.Add(entity);
            _bc.SaveChanges();

        }

        public IEnumerable<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetById(int id)
        {
            return _entity.Find(id);
        }

        public void Remove(T entity)
        {
            _entity.Remove(entity);
            _bc.SaveChanges();

        }

        public void Update(T entity)
        {
            _entity.AddOrUpdate(entity);
            _bc.SaveChanges();
        }
    }
}
