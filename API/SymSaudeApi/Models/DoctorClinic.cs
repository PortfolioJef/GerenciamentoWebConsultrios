using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SymSaudeApi.Models
{
    public class DoctorClinic
    {
        [Key]

        public int Id { get; set; }
        public int IdDoctor { get; set; }

        public int IdClinic { get; set; }

    }
}
