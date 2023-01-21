using System.ComponentModel.DataAnnotations;

namespace WebApplication1_project_.Models
{
    public class Farm
    {
        [Key]
        public Guid FarmId { get; set; }
        public string Name { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
