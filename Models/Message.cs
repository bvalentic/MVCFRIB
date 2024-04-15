namespace MVCFRIB.Models
{
    public class Message
    {
        public Message()
        {
            this.id = 1;
            this.messageContent = "";
            this.Sent = DateTime.Now;
        }
        public int id {  get; set; }
        public string messageContent { get; set; }
        public DateTime Sent {  get; set; }
    }
}
