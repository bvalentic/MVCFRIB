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

        // "Index" for SendMessage: /Messages
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GET: Messages/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Invalid request. Id cannot be null.");
            }

            var message = await _context.Messages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound($"Message with id {id} not found.");
            }

            return View("Get", message);
        }

        // GET: Messages/List
        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                return View("List", await _context.Messages.ToListAsync());
            }
            catch (Exception ex)
            {
                // log the exception
                ModelState.AddModelError("ListMessageException", $"An error occurred while listing messages: {ex.Message}");
                return RedirectToAction("Error", ex);
            }
        }

        // POST request sent after submitting form in Index
        [HttpPost]
        public async Task<IActionResult> SendMessage([Bind("Id,MessageContent,Sent")] Message message)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(message);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    // log the exception, redirect to error page
                    ModelState.AddModelError("SendMessageException", $"An error occurred while sending the message: {ex.Message}");
                    return RedirectToAction("Error", ex);
                }
            }
            // redirect to ListMessages after sending
            return View("List", await _context.Messages.ToListAsync());
        }
    }
}
