using System.ComponentModel.DataAnnotations;

namespace Commander.BlazorClient.Models
{
    public class CommandData
    {
        public int Id { get; set; }

        [Required]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}