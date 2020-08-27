﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;//added for validation

namespace MVC3ReviewLab.Models
{
    public class ContactViewModel : Controller
    {
        [Required(ErrorMessage = "* Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Email is required")]
        [EmailAddress(ErrorMessage = "* Please provide a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Subject is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "* Message is required")]
        [UIHint("MultilineText")]
        public string Message { get; set; }
    }
}