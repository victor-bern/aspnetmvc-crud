using System.Collections.Generic;
using System.Threading.Tasks;
using crud.Data;
using crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace crud.Controllers
{

    public class UserController : Controller
    {

        [HttpGet]
        public async Task<ActionResult<List<UserViewModel>>> Index([FromServices] DataContext context)
        {
            var users = await context.Users
            .AsNoTracking()
            .ToListAsync();

            return View(users);
        }

        [HttpGet]
        public IActionResult UserNotFound()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromServices] DataContext context, [Bind] UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(model);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult<UserViewModel>> Edit([FromServices] DataContext context, int? id)
        {
            if (id == null)
                NotFound();

            var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return RedirectToAction("UserNotFound");

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult<UserViewModel>> Edit([FromServices] DataContext context, [Bind] UserViewModel model, int id)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Id = id;
            context.Entry(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult<UserViewModel>> Details([FromServices] DataContext context, int? id)
        {
            if (id == null)
                NotFound();

            var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return RedirectToAction("UserNotFound");


            return View(user);
        }


        [HttpGet]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Delete([FromServices] DataContext context, int? id)
        {
            if (id == null)
                NotFound();

            var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return RedirectToAction("UserNotFound");

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<UserViewModel>> DeleteUser([FromServices] DataContext context, int? id)
        {
            if (id == null)
                return NotFound();

            var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return RedirectToAction("UserNotFound");

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}