using System.ComponentModel.DataAnnotations;

namespace Task_6_Blazor_Server.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public UserModel()
        {
        }

        public UserModel(string name)
        {
            Name = name;
        }
    }
}
