using Task_6_Blazor_Server.Data;
using Task_6_Blazor_Server.Models;
using Gma.DataStructures.StringSearch;

namespace Task_6_Blazor_Server.Services
{

    public interface IUserService
    {
        public UserModel? GetUserByUsername(string username);
        public UserModel? GetUserById(int id);
        public UserModel CreateUser(string username);
        public List<UserModel> GetAllUsers();
        public UkkonenTrie<string> GetAllUsernames();
    }

    public class UserService : IUserService
    {
        ApplicationDbContext _dbContext;
        static UkkonenTrie<string> _cachedUsernames { get; set; }

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserModel? GetUserByUsername(string username)
        {
            UserModel? user = _dbContext.Users.Where(u => u.Name.Equals(username)).FirstOrDefault();
            return user;
        } 
        
        public UserModel? GetUserById(int id)
        {
            UserModel? user = _dbContext.Users.Where(u => u.Id.Equals(id)).FirstOrDefault();
            return user;
        }

        public UserModel CreateUser(string username)
        {
            UserModel newUser =  _dbContext.Users.Add(new UserModel(username)).Entity;
            _dbContext.SaveChanges();
            return newUser;
        }

        public List<UserModel> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public UkkonenTrie<string> GetAllUsernames()
        {
            if (_cachedUsernames != null)
                return _cachedUsernames;
            List<string> usernames = _dbContext.Users.Select(u => u.Name).ToList();
            UkkonenTrie<string> usernamesInTrie = new UkkonenTrie<string>(1);
            foreach(var username in usernames)
            {
                usernamesInTrie.Add(username , username);
            }
            return usernamesInTrie;
        }
    }
}
