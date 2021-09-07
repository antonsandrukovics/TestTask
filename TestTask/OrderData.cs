using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask
{
    public class OrderData
    {
        public int OrderID { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Client email")]
        public string ClientEmail { get; set; }
        [Display(Name = "Product ID")]
        public int? ProductId { get; set; }
        [Display(Name = "Product title")]
        public string ProductTitle { get; set; }


        [RegularExpression("0*[1-9][0-9]*")]
        [Required]
        [Display(Name = "Product quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Order status")]
        public Status Status { get; set; }


        [Display(Name = "Total order price")]
        [DataType(DataType.Currency)]
        public decimal OrderPrice { get; set; }
    }
}
