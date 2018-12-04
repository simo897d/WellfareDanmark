using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamAPI.Models
{
    public class Teams
    {
        public List<Users> Participants { get; set; }
        public DateTime Date { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
