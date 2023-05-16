using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    [Owned]
    public class FullName
    {
        [MinLength(3, ErrorMessage = "longueur minimale 3 caractères")]
        [MaxLength(25, ErrorMessage = "de longueur maximale 25 caractères")]
        public string FirstName { get; set; }
        public string LastName { get; set; } 
    }
}
