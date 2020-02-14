using System.ComponentModel.DataAnnotations;

namespace Lagerverwaltung.ViewModels
{
    public class PasswortFestlegenViewModel
    {
        [Required]

        public string User { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Passwort { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Passwort", ErrorMessage = "Passwörter müssen gleich sein")]
        public string ConfirmPasswort { get; set; }
    }
}
