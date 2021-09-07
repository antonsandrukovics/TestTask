using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public enum Status
    {
        Created,
        Paid,
        Delivered
    }
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int? ClientId { get; set; }
        public Client Client { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }


        [RegularExpression("0*[1-9][0-9]*")]
        [Required]
        public int Quantity { get; set; }
        public Status Status { get; set; }

        public decimal GetOrderPrice()
        {
            return Product.Price * Quantity;
        }
    }
}
