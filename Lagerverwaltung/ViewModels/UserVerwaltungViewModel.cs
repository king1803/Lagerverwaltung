using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lagerverwaltung.ViewModels
{
    public class UserVerwaltungViewModel
    {
        public string UserName { get; set; }

        public List<Userberechtigung> Users { get; set; }
    }
}
