using System.ComponentModel.DataAnnotations;

namespace ApiYemek23.Entities.AppEntities
{
    public class LoginModel
    {
        public string mail {  get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string password { get; set; }
    }
}
