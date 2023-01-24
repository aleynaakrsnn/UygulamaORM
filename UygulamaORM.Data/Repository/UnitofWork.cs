using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UygulamaORM.Data.Repository.IRepository;

namespace UygulamaORM.Data.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _context;

        public UnitofWork(ApplicationDbContext context)
        {
            _context = context;
        }   

        public IKategoriRepository Kategori =>  new KategoriRepository(_context);

        public IUrunlerRepository Urunler =>  new UrunlerRepository(_context); //tablolarımız

        public void Dispose()
        {
          _context.Dispose();
        }
  public void Save()
        {
            _context.SaveChanges();

        }
    }
}
