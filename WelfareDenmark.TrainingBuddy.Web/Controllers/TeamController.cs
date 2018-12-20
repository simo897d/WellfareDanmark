using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class TeamController : Controller
    {
        private readonly MyDataBaseContext _context;

        public TeamController(MyDataBaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var myDataBaseContext = _context.TeamTable.Include(t => t.Exercise).Include(t => t.User);
            return View(await myDataBaseContext.ToListAsync());
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
    }
}