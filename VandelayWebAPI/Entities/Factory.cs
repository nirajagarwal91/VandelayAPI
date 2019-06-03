using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VandelayWebAPI.Entities
{
    public class Factory
    {
        [Key]
        public int FactoryId { get; set; }
        [Required]
        public string FactoryName { get; set; }
        [Required]
        [MaxLength(100)]
        public string FactoryDescription { get; set; }
        [Required]
        //public Address FactoryAddress { get; set; }

        public ICollection<Machine> Machines { get; set; } = new List<Machine>();
    }
}
