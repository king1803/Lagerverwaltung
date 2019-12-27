﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.ViewModels
{
    public class RegestrierenViewModel
    {
        [Required]

        public String UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Passwort { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Passwort",ErrorMessage ="Passwörter müssen gleich sein")]

        public string ConfirmPasswort  { get; set; }

        
}
}