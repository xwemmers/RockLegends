using System.ComponentModel.DataAnnotations;

namespace RockLegends.Models
{
    public class Artist
    {
        [Key]
        public int ArtistID { get; set; }

        [Display(Name="Naam artiest")]
        [StringLength(40)]
        [Required(ErrorMessage = "De naam is verplicht")]
        //[RegularExpression("[0-9] ?{4}[A-Za-z]{2}")]        // voor als je een postcode wilt hebben
        public string Name { get; set; } = "";

        public int BeginYear { get; set; }

        public int? EndYear { get; set; }

        public byte[]? Photo { get; set; }

        public virtual ICollection<Album>? Albums { get; set; }
    }
}
