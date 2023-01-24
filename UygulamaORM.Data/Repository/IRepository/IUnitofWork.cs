using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UygulamaORM.Data.Repository.IRepository
{
    public  interface IUnitofWork:IDisposable
    {
        IKategoriRepository Kategori { get; }

        IUrunlerRepository Urunler { get; }

        void Save();

    }
}
