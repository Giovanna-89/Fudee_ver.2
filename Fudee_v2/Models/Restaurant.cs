using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Fudee_v2.Models
{
    public class Restaurant
    {
        [Key]
        [Display(Name = "Identyfikator:")]
        public int IdRestaurant { get; set; }

        [Required]
        [Display(Name = "Nazwa restauracji")]
        [MaxLength(100, ErrorMessage = "Nazwa restauracji nie może przekraczać 100 znaków")]
        public string? NameRestaurant { get; set; }

        [Required]
        [Display(Name = "Adres restauracji:")]
        public int IdAddress { get; set; }
        [ForeignKey("IdAddress")]
        public virtual Address? Address { get; set; }

        [Display(Name = "LOGO restauracji:")]
        [MaxLength(128)]
        [FileExtensions(Extensions = ". jpg,. png,. gif", ErrorMessage = "Niepoprawne rozszerzenie pliku.")]
        public string? Logo { get; set; }

        [Required]
        [Display(Name = "Opis restauracji:")]
        [MaxLength(300, ErrorMessage = "Opis restauracji nie może przekraczać 300 znaków")]
        public string? DescriptionRestaurant { get; set; }

        [Required]
        [Display(Name = "Dostawa:")]
        public bool HasDelivery { get; set; }

        [Required]
        [Display(Name = "Catering:")]
        public bool HasCatering { get; set; }

        [Required]
        [Display(Name = "Imprezy okolicznościowe:")]
        public bool Events { get; set; }

        [Required]
        [Display(Name = "Social Media:")]
        public string? SocialMedia { get; set; }

        [Required]
        [Display(Name = "Data dodania:")]
        [DataType(DataType.Date, ErrorMessage = "Niepoprawny format daty")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public System.DateTime AddedDate { get; set; }

        [Display(Name = "Kategoria restauracji:")]
        public int IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public virtual Category? Category { get; set; }

        [Display(Name = "Właścicel/menager:")]
        public string? Id { get; set; }
        [ForeignKey("Id")]
        public virtual AppUser? User { get; set; }

        public virtual List<Opinion>? Opinions { get; set; }
        public virtual List<Dish>? Dishes { get; set; }
    }
}
