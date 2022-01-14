using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockLegends.Models
{

    public class Album
    {
        public int AlbumID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public int Year { get; set; }

        [ForeignKey(nameof(ArtistId))]
        public virtual Artist? Artist { get; set; }


        // Dit is de oudere variant (die nog wel werkt)
        //[DisplayName("Artiest1")]

        [Display(Name = "Artiest")]
        public int ArtistId { get; set; }
    }
}
