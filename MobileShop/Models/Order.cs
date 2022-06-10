using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileShop.Models
{
    public class Order
    {
        /// <summary>
        /// Primary Key : Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// customer id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// time of create order
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// status order
        /// this prop can have 'complete' , 'canceled' , 'in_process' items
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// list of an order item
        /// </summary>
        public virtual List<OrderItem> Items { get; set; }
    }
}