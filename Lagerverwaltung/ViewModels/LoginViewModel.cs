using System.ComponentModel.DataAnnotations;

namespace Lagerverwaltung.ViewModels
{
    public class LoginViewModel
    {
        [Required]

        public string User { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Passwort { get; set; }





    }
}
