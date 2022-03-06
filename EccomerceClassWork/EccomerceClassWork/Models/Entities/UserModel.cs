using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EccomerceClassWork.Models.Entities
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
        //[Required]
        public string Type { get; set; }
    }
}