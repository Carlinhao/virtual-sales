﻿using System;

namespace SalesMvc.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string CPF { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
