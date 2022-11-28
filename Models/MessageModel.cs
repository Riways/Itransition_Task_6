using System.ComponentModel.DataAnnotations;

namespace Task_6_Blazor_Server.Models
{
    public class MessageModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RecipientId { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public string MessageTitle { get; set; }
        [Required]
        public string MessageBody { get; set; }
        [Required]
        public DateTime DateOfSending { get; set; }
        

        public MessageModel()
        {
        }

        public MessageModel( int senderId, int recipientId, string messageTitle, string messageBody, DateTime dateOfSending)
        {
            RecipientId = recipientId;
            SenderId = senderId;
            MessageTitle = messageTitle;
            MessageBody = messageBody;
            DateOfSending = dateOfSending;
        }
    }
}
