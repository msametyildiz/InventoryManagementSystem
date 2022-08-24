using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem4.Models
{
    public class CategoryType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        
    }
}
