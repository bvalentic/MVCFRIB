using Microsoft.AspNetCore.Mvc;
using MVCFRIB.Data;

namespace MVCFRIB.Controllers
{
    public class MessageController : Controller
    {
        private readonly MessageContext _context;

        public MessageController(MessageContext context)
        {
            _context = context;
        }
        public IActionResult ListMessages()
        {
            return View(_context.Messages.ToList());
        }

        public IActionResult SendMessage() 
        {
            return View();
        }
    }
}
