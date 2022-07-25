using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RopayDvd.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Login ID is missing.")]
        public string LoginId { get; set; }
        [Required(ErrorMessage ="Passcode is missing.")]
        [DataType(DataType.Password)]
        public string LoginCode { get; set; }
    }
}
