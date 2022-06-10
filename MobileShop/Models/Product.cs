using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MobileShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        /// <summary>
        /// category entity
        /// </summary>
        public virtual Category Category { get; set; }
    }
}