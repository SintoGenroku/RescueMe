using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RescueMe.Client.Models.Requests.Account
{
    public class LoginRequestModel
    {
        public string PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}
