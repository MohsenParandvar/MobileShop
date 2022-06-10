using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobileShop.Models
{
    public class OrderItem
    {
        /// <summary>
        /// primary key : Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Product Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Order Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Virtual Model prop : Order
        /// </summary>
        public virtual Order Order { get; set; }
    }
}