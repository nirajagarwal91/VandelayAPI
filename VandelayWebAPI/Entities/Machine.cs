using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VandelayWebAPI.Entities
{
    public class Machine
    {
        [Key]
        public int MachineId { get; set; }

        [Required]
        [MaxLength(50)]
        public string MachineName { get; set; }
        [MaxLength(100)]
        public string MachineDescription { get; set; }

        [ForeignKey("FactoryId")]
        public Factory Factory { get; set; }
        public int FactoryId { get; set; }
    }
}
