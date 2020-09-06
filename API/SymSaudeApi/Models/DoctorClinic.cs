using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SymSaudeApi.Models
{
    [Table("doctor_clinic")]
    public class DoctorClinic
    {
        [Key]

        public int Id { get; set; }
        public int IdDoctor { get; set; }

        public int IdClinic { get; set; }

    }
}
