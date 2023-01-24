using Microsoft.AspNetCore.Mvc;
using UygulamaORM.Models;
using UygulamaORM.Data.Repository.IRepository;

namespace UygulamaORM.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class KategoriController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        public KategoriController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Kategori> kategoriList = _unitofWork.Kategori.GetAll();

            return View(kategoriList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.Kategori.Add(kategori);
                _unitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(kategori);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var kategori = _unitofWork.Kategori.GetFirstOrDefault(x => x.Id == id);
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }
        [HttpPost]

        public IActionResult Edit(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.Kategori.Update(kategori);
                _unitofWork.Save();
                return RedirectToAction("Index");
            }
            return View(kategori);
        }
        public IActionResult Delete(int id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var kategori = _unitofWork.Kategori.GetFirstOrDefault(x => x.Id == id);
            if (kategori == null)
            {
                return NotFound();

            }
            _unitofWork.Kategori.Remove(kategori);
            _unitofWork.Save();
            return RedirectToAction("Index");
        }
    }
}
