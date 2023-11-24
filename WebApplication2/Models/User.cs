using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalMatchesPlayed { get; set; }
        public int Contactnumber { get; set; }
        public string Email {  get; set; }
        public DateTime DateOfBirth {  get; set; }
        public decimal Height {  get; set; }
        public decimal Weight {  get; set; }

        public string Password { get; set; }
        public int RoleId { get; set; }


    }
}
