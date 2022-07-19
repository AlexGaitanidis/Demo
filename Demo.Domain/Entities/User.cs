using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        [Required]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public UserRole Role { get; set; }

        public void UpdateInfo(string firstName, string lastName, string email, int roleId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            RoleId = roleId;
        }
    }
}
