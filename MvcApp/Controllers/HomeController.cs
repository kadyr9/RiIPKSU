using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;
using static System.Formats.Asn1.AsnWriter;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
            if (!db.Cloth_types.Any())
            {
                Cloth_type shirt = new Cloth_type { Name_cloth_type = "Рубашка" };
                Cloth_type trousers = new Cloth_type { Name_cloth_type = "Брюки" };
                Cloth_type tshirt = new Cloth_type { Name_cloth_type = "Футболка" };
                Cloth_type sweatshirt = new Cloth_type { Name_cloth_type = "Спортивка" };

                db.Cloth_types.AddRange(shirt, trousers, tshirt, sweatshirt);

                db.SaveChanges();
            }
        }
        public async Task<IActionResult> Index(string cloth_size,
           string cloth_brand, int cloth_type = 0, int page = 1)
        {
            int pageSize = 3;

           
            IQueryable<Cloth> clothes = db.Clothes.Include(x => x.Cloth_type);

            if (cloth_type != 0)
            {
                clothes = clothes.Where(p => p.Id_type_cloth == cloth_type);
            }
            if (!string.IsNullOrEmpty(cloth_size))
            {
                clothes = clothes.Where(p => p.Cloth_size!.Contains(cloth_size));
            }
         
            var count = await clothes.CountAsync();
            var items = await clothes.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel(
                items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel(db.Cloth_types.ToList(), cloth_type, cloth_brand)
            );
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewBag.Cloth_types = new SelectList(db.Cloth_types, "Id", "Name_cloth_type");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cloth cloth)
        {
            cloth.Cloth_type = db.Cloth_types.FirstOrDefault(e => e.Id == cloth.Id_type_cloth);
            db.Clothes.Add(cloth);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Cloth cloth = new Cloth { Id = id.Value };
                db.Entry(cloth).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
