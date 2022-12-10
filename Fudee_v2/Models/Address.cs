using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Fudee_v2.Models
{
    public class Address
    {
        [Key]
        [Display(Name = "Identyfikator:")]
        public int IdAddress { get; set; }

        [Required(ErrorMessage = "Proszę podać miejscowość:")]
        [Display(Name = "Miejscowość:")]
        [MaxLength(30, ErrorMessage = "Nazwa mejscowości nie może przekroczyć 30 znaków")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę ulicy:")]
        [Display(Name = "Nazwa ulica:")]
        [MaxLength(70, ErrorMessage = "Nazwa ulicy nie może przekroczyć 70 znaków")]
        public string? StreetName { get; set; }

        [Required(ErrorMessage = "Proszę podać numer ulicy:")]
        [Display(Name = "Numer ulicy:")]
        public string? StreetNr { get; set; }

        [Required(ErrorMessage = "Proszę podać numer lokalu:")]
        [Display(Name = "Numer lokalu:")]
        public int? LocalNr { get; set; }

        [Required(ErrorMessage = "Proszę podać kod pocztowy:")]
        [Display(Name = "Kod pocztowy:")]
        [StringLength(5, ErrorMessage = "Kod pocztowy musi mieć 5 znaków")]
        public string? PostCode { get; set; }

        [Required]
        [Display(Name = "Email:")]
        public string? ContactEmail { get; set; }

        [Required]
        [Display(Name = "Telefon:")]
        [StringLength(9, ErrorMessage = "Błędny numer")]
        public string? ContactPhone { get; set; }

        public virtual Restaurant? Restaurant { get; set; }
    }
}
