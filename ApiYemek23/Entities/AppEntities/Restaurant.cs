using System.ComponentModel.DataAnnotations;

namespace ApiYemek23.Entities.AppEntities
{
    public class Restaurant
    {
        [Key]
        public int Restaurant_Id { get; set; }
        [Key]
        public string Restaurant_code { get; set; }
        [Required]
        public string Restaurant_Name { get; set; }
        [Required]
        public string  Restaurant_Location { get; set; }
        [Required]
        public string Restaurant_Phone_Number { get; set; }
        [Required]
        public string Restaurant_Coordinates { get; set; }
        [Required]
        public int Restaurant_Rating {  get; set; }

    }
}
