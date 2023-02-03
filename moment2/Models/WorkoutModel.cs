using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moment2.Models
{
    public class WorkoutModel
    {
        // Properties

        [Required(ErrorMessage = "Du måste ange träningsform")]
        [Display(Name = "Vilken typ av träning var det?")]
        public string? Type { get; set; }

        [Required(ErrorMessage = "Du måste ange beskrivning")]
        [Display(Name = "Beskriv vad du gjort?")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Du måste ange längd")]
        [Display(Name = "Hur länge tränade du?")]
        public int? Duration { get; set; }

        [Required(ErrorMessage = "Du måste ange datum")]
        [Display(Name = "Vilket datum tränade du?")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Du måste ange hur det kändes")]
        [Display(Name = "Hur kändes träningen?")]
        public string? Feel { get; set; }

    }
}
