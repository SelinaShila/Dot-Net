using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_ATM.Models
{
    public class Accounts
    {
        [Key]
        
        [Required(ErrorMessage = "Please enter Card Number!.")]
        public int CardNumber { get; set; }

        [Required(ErrorMessage = "Please enter Pin Number!.")]
        public int PinNumber { get; set; }

        [Required(ErrorMessage = "Please enter your balance!.")]
        public int Balance { get; set; }
    }
}