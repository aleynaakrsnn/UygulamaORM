using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UygulamaORM.Data.Repository.IRepository;
using UygulamaORM.Models;

namespace UygulamaORM.Data.Repository
{
    public class UrunlerRepository : Repository<Urunler>, IUrunlerRepository
    {
        private ApplicationDbContext _context;
        public UrunlerRepository(ApplicationDbContext context) : base(context)
        {
                
                _context = context;
            
        }
    }
}
