using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamAPI.Models
{
    public class Teams
    {
        [Key]
        public int TeamsID { get; set; }
        public List<Users> Participants { get; set; }
        public DateTime Date { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
