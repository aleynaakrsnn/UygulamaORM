using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UygulamaORM.Models
{
    public class Urunler
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UrunAdi { get; set; }

        [Required]
        public string Aciklama { get; set; }

        [Required]
        public string Barcode { get; set; }

        [Required]
        public double Fiyat { get; set; }

        [Required]
        public int KategoriId { get; set; }

        [Required]
        public string Resim { get; set; }

        [Required]
        [ForeignKey("KategoriId")]
        public Kategori Kategori { get; set; }
    }
}
