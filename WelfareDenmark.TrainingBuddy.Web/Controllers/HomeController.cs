using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WelfareDenmark.TrainingBuddy.Web.Models;

namespace WelfareDenmark.TrainingBuddy.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly MyDataBaseContext _context;

        public HomeController(MyDataBaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var myDataBaseContext = _context.TeamTable.Include(t => t.Exercise).Include(t => t.User);
            return View(await myDataBaseContext.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: TeamTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamTable = await _context.TeamTable
                .Include(t => t.Exercise)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (teamTable == null)
            {
                return NotFound();
            }

            return View(teamTable);
        }

        public IActionResult CreateTeam()
        {
            var viewModel = new TeamViewModel();
            viewModel.Exercises = _context.Exercises.Select(item => new SelectListItem { Value = item.ExerciseId.ToString(), Text = item.ExerciseName }).ToList();
            viewModel.SelectedExercise = viewModel.Exercises.First();

            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "ExerciseId", "ExerciseName");
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Email");
            // ViewData["Email"] = new SelectList(_context.AspNetUsers, "Email", "Email");
            return View(viewModel);
        }

        // POST: TeamTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeam([Bind("TeamId,UserId,ExerciseId,Date,Email")] TeamTable teamTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teamTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "ExerciseId", "ExerciseName", teamTable.ExerciseId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", teamTable.UserId);
            ViewData["Email"] = new SelectList(_context.AspNetUsers, "Email", "Email", teamTable.Email);
            return View(teamTable);
        }

        // GET: TeamTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamTable = await _context.TeamTable.FindAsync(id);
            if (teamTable == null)
            {
                return NotFound();
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "ExerciseId", "ExerciseName", teamTable.ExerciseId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", teamTable.UserId);
            return View(teamTable);
        }

        // POST: TeamTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamId,Email,UserId,ExerciseId,Date")] TeamTable teamTable)
        {
            if (id != teamTable.TeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamTableExists(teamTable.TeamId))
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
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, "ExerciseId", "ExerciseName", teamTable.ExerciseId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", teamTable.UserId);
            return View(teamTable);
        }

        // GET: TeamTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamTable = await _context.TeamTable
                .Include(t => t.Exercise)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (teamTable == null)
            {
                return NotFound();
            }

            return View(teamTable);
        }

        // POST: TeamTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teamTable = await _context.TeamTable.FindAsync(id);
            _context.TeamTable.Remove(teamTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamTableExists(int id)
        {
            return _context.TeamTable.Any(e => e.TeamId == id);
        }
    }
}
