using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Film_lib.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Username { get; set; }
        [MaxLength(256)]
        public required string PasswordHash { get; set; }
        public required string Email { get; set; }
        public string Role { get; set; } = "User";
    }
}
