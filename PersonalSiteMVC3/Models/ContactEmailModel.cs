using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PersonalSiteMVC3.Models
{
        public class ContactEmailModel
        {
            [Required(ErrorMessage = "Name is required")]
            public string Name { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            [Required]
            public string Subject { get; set; }
            [Required]
            [UIHint("MultilineText")]
            public string Message { get; set; }
        } 
}