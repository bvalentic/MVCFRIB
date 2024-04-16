namespace MVCFRIB.Models
{
    public class Message(string messageContent)
    {
        public int id {  get; set; }
        public string messageContent { get; set; } = messageContent;
        public DateTime Sent { get; set; } = DateTime.Now;
    }
}
