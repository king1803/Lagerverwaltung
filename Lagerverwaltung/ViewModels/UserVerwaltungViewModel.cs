using System.Collections.Generic;

namespace Lagerverwaltung.ViewModels
{
    public class UserVerwaltungViewModel
    {
        public string UserName { get; set; }

        public List<Userberechtigung> Users { get; set; }
    }
}
