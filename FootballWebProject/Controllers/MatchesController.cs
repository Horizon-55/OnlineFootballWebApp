using FootballWebProject.Data;
using FootballWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FootballWebProject.Controllers
{
    public class MatchesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MatchesController(ApplicationDbContext context)
        {
            _context = context;
        }
        //methods if matches exist by id
        private bool MatchesExists(int id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }
        //get matches
        public async Task<IActionResult> Index()
        {
            var matches = await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.GuestTeam)
                .ToListAsync();
            return View(matches);
        }
        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matches = await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.GuestTeam)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matches == null)
            {
                return NotFound();
            }

            return View(matches);
        }
        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "ID", "Name");
            ViewData["GuestTeamId"] = new SelectList(_context.Teams, "ID", "Name");
            return View();
        }

        // POST: Matches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,HomeTeamId,GuestTeamId,HomeScore,GuestScore")] Matches matches)
        {
            if (ModelState.ErrorCount == 2)
            {
                _context.Add(matches);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "ID", "Name", matches.HomeTeamId);
            ViewData["GuestTeamId"] = new SelectList(_context.Teams, "ID", "Name", matches.GuestTeamId);
            return View(matches);
        }
        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matches = await _context.Matches.FindAsync(id);
            if (matches == null)
            {
                return NotFound();
            }
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "ID", "Name", matches.HomeTeamId);
            ViewData["GuestTeamId"] = new SelectList(_context.Teams, "ID", "Name", matches.GuestTeamId);
            return View(matches);
        }
        // POST: Matches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,HomeTeamId,GuestTeamId,HomeScore,GuestScore")] Matches matches)
        {
            if (id != matches.Id)
            {
                return NotFound();
            }

            if (ModelState.ErrorCount == 2)
            {
                try
                {
                    _context.Update(matches);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchesExists(matches.Id))
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
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "ID", "Name", matches.HomeTeamId);
            ViewData["GuestTeamId"] = new SelectList(_context.Teams, "ID", "Name", matches.GuestTeamId);
            return View(matches);
        }
        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matches = await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.GuestTeam)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matches == null)
            {
                return NotFound();
            }

            return View(matches);
        }
        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matches = await _context.Matches.FindAsync(id);
            _context.Matches.Remove(matches);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
