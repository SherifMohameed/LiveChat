using LiveChat.Data;
using LiveChat.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveChat.Hubs
{
    public class ChatHubs:Hub
    {

        private readonly ApplicationDbContext _context;
        public ChatHubs(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string userName,string message)
        {
            var AdminId = _context.UserRoles.Where(r => r.RoleId == "1").Select(u => u.UserId).FirstOrDefault();
            var userId=_context.AppUsers.Where(n => (n.FirstName + " " + n.LastName) == userName).Select(i => i.Id).FirstOrDefault();

            if (userId!=AdminId)
            {
                await Clients.Caller.SendAsync("ReciveMessage", userName, message);
                await Clients.User(AdminId).SendAsync("ReciveMessage", userName, message);
            }
            else
            {
                await Clients.Caller.SendAsync("ReciveMessage", userName, message);
                await Clients.User(userId).SendAsync("ReciveMessage", userName, message);
            }

            //await Clients.All.SendAsync("ReciveMessage", message);

        }


    }
}
