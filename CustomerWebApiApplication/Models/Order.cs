using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerWebApiApplication.Models
{
    public class Order
    {
        public int Id { get; set; }
        [StringLength(80)]
        [Required]
        public string Description  { get; set; }
        public decimal? Total { get; set; }
        public bool? Fulfilled { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}