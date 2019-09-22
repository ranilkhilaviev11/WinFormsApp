using System.ComponentModel.DataAnnotations;

namespace WinFormsApp.Model
{
    public class Player
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
