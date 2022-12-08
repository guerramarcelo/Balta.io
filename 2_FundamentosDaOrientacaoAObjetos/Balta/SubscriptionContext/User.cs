using Balta.SharedContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Balta.SubscriptionContext
{
    public class User : Base
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
