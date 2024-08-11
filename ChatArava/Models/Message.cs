using System.ComponentModel.DataAnnotations;

namespace ChatArava.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string textContent { get; set; }

        public User sender { get; set; }

        public DateTime timeStentd { get; set; }

    }
}
