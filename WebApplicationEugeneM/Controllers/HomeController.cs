using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationEugeneM.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplicationEugeneM.Controllers
{
    public class HomeController : Controller
    {
        UsersContext db;
        public HomeController(UsersContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index(string name, int company = 0, int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<User>? users = db.Users.Include(x => x.Company);
            if (company != null && company != 0)
            {
                users = users.Where(p => p.CompanyId == company);
            }
            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name!.Contains(name));
            }

            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["AgeSort"] = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;
            ViewData["CompSort"] = sortOrder == SortState.CompanyAsc ? SortState.CompanyDesc : SortState.CompanyAsc;

            users = sortOrder switch
            {
                SortState.NameDesc => users.OrderByDescending(s => s.Name),
                SortState.AgeAsc => users.OrderBy(s => s.Age),
                SortState.AgeDesc => users.OrderByDescending(s => s.Age),
                SortState.CompanyAsc => users.OrderBy(s => s.Company!.Name),
                SortState.CompanyDesc => users.OrderByDescending(s => s.Company!.Name),
                _ => users.OrderBy(s => s.Name),
            };

            List<Company> companies = db.Companies.ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            companies.Insert(0, new Company { Name = "Все", Id = 0 });

            int pageSize = 3;   // количество элементов на странице
            IQueryable<User> source = db.Users.Include(x => x.Company);

            // пагинация
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel(items, new PageViewModel(count,page,pageSize), new FilterViewModel(db.Companies.ToList(), company, name),new SortViewModel(sortOrder))
            {
                Users = await users.AsNoTracking().ToListAsync(),
                Companies = new SelectList(companies, "Id", "Name", company),
                Name = name,
                SortViewModel = new SortViewModel(sortOrder)
            };
            return View(viewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                    User user = new User { Id = id.Value };
                    //Company company = new Company { Id = id.Value };
                    db.Entry(user).State = EntityState.Deleted;
                   // db.Entry(company).State = EntityState.Modified;
                    db.Users.Remove(user);
                   // db.Companies.Remove(company);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                User? user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
                Company? company = await db.Companies.FirstOrDefaultAsync(p => p.Id == user.CompanyId);
                user.Company = company;
                if (user != null) return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
