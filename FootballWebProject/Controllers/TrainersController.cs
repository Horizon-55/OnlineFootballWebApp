using FootballWebProject.Data;
using FootballWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FootballWebProject.Controllers
{
    public class TrainersController : Controller
    {
        private readonly ApplicationDbContext _context;
        //methods
        private bool TrainersExists(int id)
        {
            return _context.Trainers.Any(e => e.Id == id);
        }
        public TrainersController(ApplicationDbContext context)
        {
            _context = context;
        }
        //get Trainers
        public async Task<IActionResult> Index()
        {
            var trainers = await _context.Trainers.Include(t => t.Team).ToListAsync();
            return View(trainers);
        }
        // GET: Trainers/Create
        public IActionResult Create()
        {
            ViewData["TeamsId"] = new SelectList(_context.Teams, "ID", "Name");
            return View();
        }

        // GET: Trainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainers = await _context.Trainers
                .Include(t => t.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainers == null)
            {
                return NotFound();
            }

            return View(trainers);
        }

        // POST: Trainers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,TeamsId")] Trainers trainers)
        {
            if (ModelState.ErrorCount == 1)
            {
                _context.Add(trainers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamsId"] = new SelectList(_context.Teams, "ID", "Name", trainers.TeamsId);
            return View(trainers);
        }
        // GET: Trainers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainers = await _context.Trainers.FindAsync(id);
            if (trainers == null)
            {
                return NotFound();
            }
            ViewData["TeamsId"] = new SelectList(_context.Teams, "ID", "Name", trainers.TeamsId);
            return View(trainers);
        }

        // POST: Trainers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,TeamsId")] Trainers trainers)
        {
            if (id != trainers.Id)
            {
                return NotFound();
            }

            if (ModelState.ErrorCount == 1)
            {
                try
                {
                    _context.Update(trainers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainersExists(trainers.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamsId"] = new SelectList(_context.Teams, "ID", "Name", trainers.TeamsId);
            return View(trainers);
        }

        // GET: Trainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainers = await _context.Trainers
                .Include(t => t.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainers == null)
            {
                return NotFound();
            }

            return View(trainers);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainers = await _context.Trainers.FindAsync(id);
            _context.Trainers.Remove(trainers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
