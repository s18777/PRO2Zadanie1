using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PRO2Zadanie1.Models
{
    public class User
    {
        [Required]
        [MaxLength(200)]
        public string Login { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        public string HashedPassword { get; set; }
        [Required]
        [MaxLength(255)]
        public string RefreshToken { get; set; }
    }
}
