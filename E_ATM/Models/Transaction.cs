using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_ATM.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int CardNUmber { get; set; }
        public int Amount { get; set; }
        public int Balance { get; set; }

    }
}