using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {

        }

        public Product(string name, string description, int numberInStock, int categoryID)
        {
            Name = name;
            Description = description;
            NumberInStock = numberInStock;
            CategoryID = categoryID;
        }

        public Product(int id, string name, string description, int numberInStock, int categoryID)
        {
            ID = id;
            Name = name;
            Description = description;
            NumberInStock = numberInStock;
            CategoryID = categoryID;
        }

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Use 2-50 character!")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Use little more 50 character!")]
        public string Description { get; set; }
        
        [Required]
        [Range(1, 9999, ErrorMessage = "Quantity must be greater than 0!")]
        public int NumberInStock { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        
    }
}