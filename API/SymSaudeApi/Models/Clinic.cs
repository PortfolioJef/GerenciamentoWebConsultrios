using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SymSaudeApi.Models
{
    public class Clinic
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Adress { get; set; }
        
        [MaxLength(20)]
        public string Phone { get; set; }
    }
}
