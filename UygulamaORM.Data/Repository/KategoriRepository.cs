using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UygulamaORM.Models;
using UygulamaORM.Data.Repository.IRepository;

namespace UygulamaORM.Data.Repository
{
    public class KategoriRepository : Repository<Kategori>, IKategoriRepository
    {
        private ApplicationDbContext _context;

        public KategoriRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
