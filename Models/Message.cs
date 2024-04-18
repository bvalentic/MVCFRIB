namespace MVCFRIB.Models
{
    public class Message(string messageContent)
    {
        public int Id {  get; set; }
        public string MessageContent { get; set; } = messageContent;
        public DateTime Sent { get; set; } = DateTime.Now;
    }
}
