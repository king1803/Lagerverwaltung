using System;
using System.ComponentModel.DataAnnotations;

namespace Lagerverwaltung.ViewModels
{
    public class RolleErstellenViewModel
    {
        [Required]
        public String RollenName { get; set; }
    }
}
