using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class PartyInvitesHomeController : Controller
    {
        private IRepository repository;

        public PartyInvitesHomeController(IRepository repo){
            repository = repo;
        }

        public ViewResult Index() {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm(){
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse){
            if(ModelState.IsValid){
                repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else {
                return View();
            }
        }

        public ViewResult ListResponses(){
            return View(repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}