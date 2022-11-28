using System.ComponentModel.DataAnnotations;

namespace Task_6_Blazor_Server.Models
{
    public class DialogModel
    {
        [Key]
        public int DialogId { get; set; }
        [Required]
        public int FirstUserId { get; set; }
        [Required]
        public int SecondUserId { get; set; }
        public List<MessageModel> Messages { get; set; }

        public DialogModel()
        {
            Messages = new List<MessageModel>();
        }

        public DialogModel(int firstUserId, int secondUserId)
        {
            FirstUserId = firstUserId;
            SecondUserId = secondUserId;
            Messages = new List<MessageModel>();
        }

        public override string? ToString()
        {
            return String.Join(", ", DialogId, FirstUserId, SecondUserId, Messages.Count);
        }
    }
}
