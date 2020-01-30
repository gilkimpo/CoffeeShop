﻿using System;
using System.Collections.Generic;

namespace CoffeShop.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public decimal? Funds { get; set; }
        public string PhoneNumber { get; set; }
    }
}
