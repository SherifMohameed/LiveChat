using LiveChat.Data;
using LiveChat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveChat.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        public readonly ApplicationDbContext _context;
        //private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public ChatController(ApplicationDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task< IActionResult> Index()
        {
            var currentUser=await _userManager.GetUserAsync(User);
            var UserName = currentUser.FirstName + " " + currentUser.LastName;
            ViewBag.CurrentUserName = UserName;
            return View();
        }
    }
}
