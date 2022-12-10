using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Fudee_v2.Models
{
    public class Dish
    {
        [Key]
        [Display(Name = "Identyfikator:")]
        public int IdDishes { get; set; }

        [Required]
        [Display(Name = "Zdjęcie potrawy:")]
        [MaxLength(128)]
        [FileExtensions(Extensions = ". jpg,. png,. gif", ErrorMessage = "Niepoprawne rozszerzenie pliku.")]
        public string? ImageDish { get; set; }

        [Required]
        [Display(Name = "Nazwa potrawy:")]
        [MaxLength(30, ErrorMessage = "Nazwa potrawy nie może przekroczyć 30 znaków")]
        public string? NameDishes { get; set; }

        [Required]
        [Display(Name = "Opis potrawy:")]
        [MaxLength(255, ErrorMessage = "Opis potrawy nie może przekroczyć 255 znaków")]
        public string? DescriptionDishes { get; set; }

        [Required]
        [Display(Name = "Cena:")]
        public float? Price { get; set; }

        
        [Display(Name = "Danie restauracji:")]
        public int? IdRestaurant { get; set; }
        [ForeignKey("IdRestaurant")]

        public virtual Restaurant? Restaurant { get; set; }
    }
}
