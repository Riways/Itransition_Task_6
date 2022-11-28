using System.ComponentModel.DataAnnotations;

namespace Task_6_Blazor_Server.Models
{
    public class MessageModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public string MessageTitle { get; set; }
        [Required]
        public string MessageBody { get; set; }
        [Required]
        public DateTime DateOfSending { get; set; }

        public virtual DialogModel Dialog { get; set; }

        public MessageModel()
        {
        }

        public MessageModel( int senderId , string messageTitle, string messageBody, DateTime dateOfSending)
        {
            SenderId = senderId;
            MessageTitle = messageTitle;
            MessageBody = messageBody;
            DateOfSending = dateOfSending;
        }
    }
}
