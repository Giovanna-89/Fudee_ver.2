using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Fudee_v2.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Identyfikator kategorii:")]
        public int? IdCategory { get; set; }

        [Required(ErrorMessage = "Podaj nazwę kategorii.")]
        [Display(Name = "Nazwa kategorii")]
        [MaxLength(50, ErrorMessage = "Nazwa kategorii nie może być dłuższa niż 50 znaków.")]
        public string? NameCategory { get; set; }

        [Required(ErrorMessage = "Podaj opis kategorii.")]
        [Display(Name = "Opis kategorii:")]
        [MaxLength(300, ErrorMessage = "Opis kategorii nie może być dłuższa niż 300 znaków.")]
        public string? DescriptionCategoryy { get; set; }

        [Required(ErrorMessage = "Podaj nazwę ikony.")]
        [Display(Name = "Ikona kategorii:")]
        [MaxLength(30, ErrorMessage = "Nazwa ikony kategorii nie może być dłuższa niż 30 znaków.")]
        public string? Icon { get; set; }

        public virtual List<Restaurant>? Restaurants { get; set; }
    }
}
