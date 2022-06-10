using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MobileShop.Models
{
    /// <summary>
    /// entity class
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// name of the category
        /// </summary>
        public string Name { get; set; } 

        /// <summary>
        /// list of products
        /// </summary>
        public virtual List<Product> Products { get; set; }
    }
}