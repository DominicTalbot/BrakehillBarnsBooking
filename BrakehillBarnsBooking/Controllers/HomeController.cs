using BrakehillBarnsBooking.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace BrakehillBarnsBooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Booking(BookingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View("Confirmation", model);
        }

        public IActionResult Confirmation(ConfirmationViewModel model)
        {
            return View(model);
        }

        public IActionResult Complete()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult ContactConfirmation()
        {
            return View();
        }

        public IActionResult Messages()
        {
            // Read messages from files and pass them to the view
            List<string> messages = ReadMessagesFromFiles();
            return View(messages);
        }

        [HttpPost]
        public IActionResult SendMessage(ContactMessageModel model)
        {
            if (!ModelState.IsValid)
            {
                // Handle validation errors
                return View("Contact", model);
            }

            string fileName = $"{Guid.NewGuid()}.txt";
            string messagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Messages", fileName);
            string messageContent = $"Name: {model.Name}\nEmail: {model.Email}\nMessage: {model.Message}";

            System.IO.File.WriteAllText(messagePath, messageContent);

            // Redirect to a confirmation page
            return RedirectToAction("ContactConfirmation");
        }

        // Helper method to read messages from files
        private List<string> ReadMessagesFromFiles()
        {
            string messagesFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "Messages");
            string[] messageFiles = Directory.GetFiles(messagesFolder);
            List<string> messages = new List<string>();

            foreach (string messageFile in messageFiles)
            {
                string messageText = System.IO.File.ReadAllText(messageFile);
                messages.Add(messageText);
            }

            return messages;
        }

        [HttpPost]
        public IActionResult DeleteMessage(int index)
        {
            if (ModelState.IsValid)
            {
                string messagesDirectory = Path.Combine(_webHostEnvironment.ContentRootPath, "Messages");

                if (Directory.Exists(messagesDirectory))
                {
                    string[] messageFiles = Directory.GetFiles(messagesDirectory);

                    if (index >= 0 && index < messageFiles.Length)
                    {
                        // Delete the selected message file
                        System.IO.File.Delete(messageFiles[index]);

                        // Redirect to the "Messages" page after deleting
                        return RedirectToAction("Messages");
                    }
                }
            }

            return RedirectToAction("Messages");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
