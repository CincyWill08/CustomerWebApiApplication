using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerWebApiApplication.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        public decimal? CreditLimit { get; set; }
        public bool? Active { get; set; }
    }
}