namespace crud.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }



        public string getFirstName()
        {
            return Name.Split(' ')[0];
        }
    }
}