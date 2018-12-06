using System.ComponentModel.DataAnnotations;

namespace TeamAPI.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseID { get; set; }
        public string ExerciseName { get; set; }
    }
}