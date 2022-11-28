using Task_6_Blazor_Server.Data;
using Task_6_Blazor_Server.Models;

namespace Task_6_Blazor_Server.Services
{
    public interface IMessageService
    {
        public List<DialogModel> GetListOfDialogs(int clientId);
        public List<MessageModel> GetMessagesFromDialog(int clientId, int recipientId);
        public List<MessageModel> GetMessagesFromDialogAfterSpecifiedDate(int clientId, int recipientId, DateTime date);
        public void SendMessage(int clientId, int recipientId, MessageModel message);
    }

    public class MessageService : IMessageService
    {
        ApplicationDbContext _dbContext;

        public MessageService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DialogModel> GetListOfDialogs(int clientId)
        {
            List<DialogModel> dialogs = _dbContext.Dialogs.Where( d => d.FirstUserId == clientId || d.SecondUserId == clientId).ToList();
            return dialogs;
        }

        public List<MessageModel> GetMessagesFromDialog(int clientId, int recipientId)
        {
            DialogModel dialog = GetDialog(clientId, recipientId);
            if (dialog == null || dialog.Messages == null)
                return new List<MessageModel>();
            var messages = _dbContext.Messages.Where(m => m.Dialog.DialogId == dialog.DialogId).ToList();
            messages.Reverse();
            return messages;
        }    

        public List<MessageModel> GetMessagesFromDialogAfterSpecifiedDate(int clientId, int recipientId, DateTime date)
        {
            DialogModel dialog = GetDialog(clientId, recipientId);
            return _dbContext.Messages.Where(m => dialog.DialogId == m.Dialog.DialogId && m.DateOfSending > date).ToList();
        }

        public void SendMessage(int clientId, int recipientId, MessageModel message)
        {
            DialogModel dialog = GetDialog(clientId, recipientId);
            if (dialog == null)
            {
                CreateDialog(clientId, recipientId, message);
                return;
            }
            message.Dialog = dialog;
            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();
        }

        private DialogModel GetDialog(int clientId, int recipientId)
        {
            DialogModel? dialog = _dbContext.Dialogs.Where(d => ((d.FirstUserId == clientId && d.SecondUserId == recipientId) || (d.FirstUserId == recipientId && d.SecondUserId == clientId))).FirstOrDefault();
            return dialog;
        }

        private List<DialogModel> GetAllDialogs()
        {
            return _dbContext.Dialogs.ToList();
        }

        private DialogModel CreateDialog(int clientId, int recipientId, MessageModel message)
        {
            DialogModel dialog = new DialogModel(clientId, recipientId);
            dialog = _dbContext.Add(dialog).Entity;
            _dbContext.SaveChanges();
            message.Dialog= dialog;
            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();
            return dialog;
        }

    }
}
