using System.ComponentModel.DataAnnotations;

namespace SharePrices.Models
{
    public class Shares
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public double Price { get; set; }

    }
}
