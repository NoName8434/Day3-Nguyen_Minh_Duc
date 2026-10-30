using System.ComponentModel.DataAnnotations;

namespace Ngay3.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "name is requierd")]
        [StringLength(100, MinimumLength =2 , ErrorMessage = "Catagory name at least 2 or maximum 100 characters")]
        public string Name { get; set; } = string.Empty;
        //navigation property to Product
        public ICollection<Product>? Products { get; set; }
    }
}
