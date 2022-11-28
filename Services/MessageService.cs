using Task_6_Blazor_Server.Data;
using Task_6_Blazor_Server.Models;

namespace Task_6_Blazor_Server.Services
{
    public interface IMessageService
    {
        public List<MessageModel> GetDialog(int clientId, int recipientId);
        public List<MessageModel> GetDialogAfterSpecifiedDate(int clientId, int recipientId, DateTime date);
        public void SendMessage(int clientId, int recipientId, string title, string messageBody);
    }

    public class MessageService : IMessageService
    {
        ApplicationDbContext _dbContext;

        public MessageService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<MessageModel> GetDialog(int clientId, int recipientId)
        {
            List<MessageModel>  dialog = _dbContext.Messages.Where(m => (m.SenderId == clientId && m.RecipientId == recipientId) || (m.RecipientId == clientId && m.SenderId == recipientId)).ToList() ;
            dialog.Reverse();
            return dialog;
        }

        public List<MessageModel> GetDialogAfterSpecifiedDate(int clientId, int recipientId, DateTime date)
        {
            List<MessageModel> dialog = _dbContext.Messages.Where(m => (m.DateOfSending > date ) && ((m.SenderId == clientId && m.RecipientId == recipientId) || (m.RecipientId == clientId && m.SenderId == recipientId))).ToList();
            return dialog;
        }

        public void SendMessage(int clientId, int recipientId, string title, string messageBody)
        {
            MessageModel newMessage = new MessageModel(clientId,recipientId,title, messageBody, DateTime.UtcNow);
            _dbContext.Messages.Add(newMessage);
            _dbContext.SaveChanges();
        }

    }
}
