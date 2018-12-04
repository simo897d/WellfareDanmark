using System.ComponentModel.DataAnnotations;

namespace TeamAPI.Models
{
    public class Users
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
    }
}