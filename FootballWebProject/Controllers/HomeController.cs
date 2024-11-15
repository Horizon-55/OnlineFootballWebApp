using FootballWebProject.Data;
using FootballWebProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FootballWebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //список матчів для виводу
            var matches = await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.GuestTeam)
                .OrderByDescending(m => m.Date)
                .ToListAsync();
            //список команди для виводу
            var teams = _context.Teams.ToList();
            //список гравців з команди
            var players = _context.Players.ToList();
            //список тренерів з команд
            var trainers = _context.Trainers.ToList();
            //передача параметрів
            var viewModel = new OutputViewsFootballTeam
            {
                Matches = matches,
                Teams = teams,
                Players = players,
                Trainers = trainers,
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
