using System.Net;
using Task_6_Blazor_Server.Data;
using Task_6_Blazor_Server.Models;

namespace Task_6_Blazor_Server.Services
{
    public interface IDialogService
    {
        public List<DialogModel> GetAllCompanions(int userId);
        public void registrateNewCompanion(int firstUserId, int secondUserId);
    }

    public class DialogService : IDialogService
    {
        ApplicationDbContext _dbContext;

        public DialogService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void  createNewDialog(int firstUserId, int secondUserId)
        {
            _dbContext.Add(new DialogModel(firstUserId, secondUserId));
            _dbContext.SaveChanges();
        }

        public List<DialogModel>  GetAllDialogsWithSpecifiedUser(int userId)
        {
            List<DialogModel> allDialogs = _dbContext.Dialogs.Where(d => (d.SecondUserId == userId || d.FirstUserId == userId)).ToList();
        }
    }
}
