using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UygulamaORM.Data.Repository.IRepository;

namespace UygulamaORM.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //sadece burada kullanmak istediğim context sınıfımı okunabilir şekilde tanımladım.
        private readonly ApplicationDbContext _context;

        //yazdığıız kodları daha kısa bir şekilde tanımlama yaparak kullanmak için proje içinde rahatlıkla çağırmak adına internal yapıyorum.internal olarak db set oluşturdum kalıtım olarak alan sınıflarda kolaylıkla erişebileyim.

        internal DbSet<T> _dbSet;

        //dependency injection gerçekleşmesi constructor oluşturulup application db billgisini alalım burada depency injection aracılığıyla bu işlemi yapıyorum.
        //set kullanımının sebebi ise get set işlemlerini yapmak için pratik olarak çağırmak için yaaptım.

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                //x=x.id=1 id ye göre getirme işlemi
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }

            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperrties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperrties != null)
            {
                foreach (var item in includeProperrties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }

            }
            return query.FirstOrDefault();
        }


        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);

        }
    }

}