using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WelfareDenmark.TrainingBuddy.Web.Models
{
    public class TeamViewModel
    {


        [Display(Name = "Hold Nummer")]
        public int TeamId { get; set; }
        [Display(Name = "Brugere")]
        public long UserId { get; set; }
        [Display(Name = "Øvelser")]
        public int ExerciseId { get; set; }
        public string Email { get; set; }

        [Required]
        [Display(Name = "Exercises")]
        public SelectListItem SelectedExercise { get; set; }
        public List<SelectListItem> Exercises { get; set; }
        public Exercises Exercise { get; set; }

        [Display(Name = "Dato")]
        public DateTime Date { get; set; } = DateTime.Now;

        public AspNetUsers User { get; set; }
    }
}
