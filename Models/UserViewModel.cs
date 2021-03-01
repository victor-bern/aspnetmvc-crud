using System.ComponentModel.DataAnnotations;

namespace crud.Models
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }



        public string getFirstName()
        {
            return Name.Split(' ')[0];
        }
    }
}