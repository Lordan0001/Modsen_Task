using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}
