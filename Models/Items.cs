using System.ComponentModel.DataAnnotations;

namespace ItemsAPI.Models
{
    public class Items
    {
        public int id { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]

        public string ItemCode   { get; set; }

        public int Price { get; set; }
         
    }
}
