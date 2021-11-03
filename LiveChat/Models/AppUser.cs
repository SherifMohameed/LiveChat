using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiveChat.Models
{
    public class AppUser:IdentityUser
    {
        [Required,StringLength(20,MinimumLength =3)]
        public string FirstName { get; set; }
        [Required, StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        public virtual List<Message> Messages { get; set; }

    }
}
