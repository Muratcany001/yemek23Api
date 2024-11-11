using System.ComponentModel.DataAnnotations;

namespace ApiYemek23.Entities.AppEntities
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        [Required]
        public string User_Name { get; set; }
        [Required]
        public string User_Email { get; set; }
        [Required]
        public string User_Password { get; set; }
        [Required]
        public string User_Gender { get; set; }
        [Required]
        public string User_PhoneNumber { get; set; }
        [Required]
        public string User_birthday { get; set; }

    }
}
