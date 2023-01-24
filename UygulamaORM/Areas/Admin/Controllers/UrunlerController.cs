using Microsoft.AspNetCore.Mvc;
using UygulamaORM.Data.Repository;
using UygulamaORM.Data.Repository.IRepository;
using UygulamaORM.Models;
using UygulamaORM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UygulamaORM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UrunlerController : Controller
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UrunlerController(IUnitofWork unitofWork, IWebHostEnvironment hostEnvironment)
        {
         _unitofWork = unitofWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            var urunList = _unitofWork.Urunler.GetAll();
            return View(urunList);

        }

     
        public IActionResult Crup(int? id = 0)
        {
            UrunlerVM urunlerVM = new()
            {
                Urunler = new(),
                KategoriList = _unitofWork.Kategori.GetAll().Select(l => new SelectListItem
                {
                    Text = l.KategoriAdi,
                    Value = l.Id.ToString()
                })


            };

            if (id == null || id <= 0)
            {
                return View(urunlerVM);
            }
            urunlerVM.Urunler = _unitofWork.Urunler.GetFirstOrDefault(x => x.Id == id);
            if (urunlerVM.Urunler == null)
            {
                return View(urunlerVM);
            }

            return View(urunlerVM);

        }

        [HttpPost]

        public IActionResult Crup(UrunlerVM urunlerVM, IFormFile file)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;

            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploadRoot = Path.Combine(wwwRootPath, @"img\urunlers");
                var extension = Path.GetExtension(file.FileName);

                if (urunlerVM.Urunler.Resim != null)
                {
                    var oldPicPath = Path.Combine(wwwRootPath, urunlerVM.Urunler.Resim);
                    if (System.IO.File.Exists(oldPicPath))
                    {
                        System.IO.File.Delete(oldPicPath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(uploadRoot, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                urunlerVM.Urunler.Resim = @"\img\urunlers\" + fileName + extension;
            }
            if (urunlerVM.Urunler.Id <= 0)
            {
                _unitofWork.Urunler.Add(urunlerVM.Urunler);
            }
            else
            {
                _unitofWork.Urunler.Update(urunlerVM.Urunler);
            }
            _unitofWork.Save();
            return RedirectToAction("Index");

        }
        public IActionResult Delete

    }
}
