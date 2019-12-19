using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.ViewModels
{
    public class RolleErstellenViewModel
    {
        [Required]
        public String RollenName { get; set; }
    }
}
