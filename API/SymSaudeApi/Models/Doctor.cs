using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SymSaudeApi.Models
{
    public class Doctor
    {
        [Key]
        public int id { get; set; }

        [MaxLength(10)]
        public string CRM { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(20)]
        public string Telefone { get; set; }

        public decimal ConsultationValue { get; set; }

    }
}
