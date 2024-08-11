using ChatArava.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace ChatArava.DAL
{
    public class DataLayer:DbContext
    {
        public DataLayer(string ConnctionString) : base(GetOptions(ConnctionString))
        {
            //תוודא שיש דאטהבייס
            Database.EnsureCreated();
            //הכנסת נתונים בפעם הראשונה
            Seed();
        }

        private void Seed()
        {
            if (!users.Any())
            {
                User user = new User { userName = "moshe",password= "5456", nicName = "mosh" };
                user.MessagessesList = createMessageList(user);
                users.Add(user);
                SaveChanges();
            }
        }
        private List<Message> createMessageList(User user)
        {
            List<Message> messages = new List<Message>();
            Message message = new Message { textContent = "hey", sender = user, timeStentd = DateTime.Now };
            messages.Add(message);
            messagess.Add(message);
            return messages;
        }






        public DbSet<User> users { get; set; }

        public DbSet<Message> messagess { get; set; }



        private static DbContextOptions GetOptions(string ConnctionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnctionString).Options;
        }
    }

}
