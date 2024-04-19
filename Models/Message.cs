namespace MVCFRIB.Models
{
    public class Message()
    {
        public int Id {  get; set; }
        public string MessageContent { get; set; } = "";
        public DateTime Sent { get; set; } = DateTime.Now;
    }
}
