using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    internal class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalMactchesPlayed { get; set; }
        public int Contactnumber { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
