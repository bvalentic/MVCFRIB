using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCFRIB.Data;
using MVCFRIB.Models;

namespace MVCFRIB.Controllers
{
    public class MessagesController : Controller
    {
        private readonly MessageContext _context;

        public MessagesController(MessageContext context)
        {
            _context = context;
        }

        // GET: Messages
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        // GET: [Messages]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return View(await _context.Messages.ToListAsync());
        }

        // GET: Messages/Details/5
        [HttpGet]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Messages/Send
        [HttpPost]
        public async Task<IActionResult> Send([Bind("id,messageContent,Sent")] Message message)
        {
            if (ModelState.IsValid)
            {
                _context.Add(message);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }
    }
}
