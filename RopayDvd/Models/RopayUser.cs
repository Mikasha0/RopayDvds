using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RopayDvd.Models
{
    public partial class RopayUser
    {
        [Display(Name = "User No.")]
        public int UserNumber { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "User Type")]
        public string UserType { get; set; }
        [Display(Name = "User Password")]
        public string UserPassword { get; set; }
    }
}
