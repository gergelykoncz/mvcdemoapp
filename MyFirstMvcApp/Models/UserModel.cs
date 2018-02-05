using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstMvcApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A username az kotelezo")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Adjal meg emailt")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Add meg a korod")]
        [Range(18, 120, ErrorMessage = "Legyel 18 es 120 kozott")]
        public int Age { get; set; }
    }
}