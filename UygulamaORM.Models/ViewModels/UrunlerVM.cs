using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace UygulamaORM.Models.ViewModels
{
    public class UrunlerVM
    {
        public Urunler Urunler { get; set; }    

        public IEnumerable<SelectListItem>KategoriList { get; set; }

    }
}
