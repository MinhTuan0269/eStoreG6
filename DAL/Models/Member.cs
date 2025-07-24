using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        public string Email { get; set; }

        public string? CompanyName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public int RoleId { get; set; }

        [Required]
        public string Password { get; set; }

        public Role Role { get; set; }

        public ICollection<Order> Orders { get; set; }

        
        public bool Status { get; set; } = true;
    }
}
