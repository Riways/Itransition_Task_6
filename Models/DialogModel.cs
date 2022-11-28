namespace Task_6_Blazor_Server.Models
{
    public class DialogModel
    {
        public int Id { get; set; }
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }
        public List<MessageModel> Messages { get; set; }

        public DialogModel()
        {
        }

        public DialogModel(int firstUserId, int secondUserId)
        {
            FirstUserId = firstUserId;
            SecondUserId = secondUserId;
        }
    }
}
