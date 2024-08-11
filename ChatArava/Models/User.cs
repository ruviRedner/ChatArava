using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatArava.Models
{
    public class User
    {
        public User()
        {
            MessagessesList = new List<Message>();
        } 
        

       

        [Key]
        public int Id { get; set; }

        public string userName { get; set; }
        
        public string password { get; set; }
        [Compare("password"),NotMapped]
        public string confirmPassword { get; set; }
        public string nicName { get; set; }

        public List<Message> MessagessesList { get; set; }
    }
}
