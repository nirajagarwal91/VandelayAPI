using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VandelayWebAPI.Models
{
    public abstract class InventoryItemManipulation
    {
        [Required(ErrorMessage = "You should fill out Item SKU.")]
        public int ItemSKU { get; set; }

        [Required(ErrorMessage = "You should fill out the Quantity.")]
        public string ItemQuantity { get; set; }

        [Required(ErrorMessage = "You should fill in Item Name.")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "You should fill out description for the title.")]
        public string ItemDescription { get; set; }

        [DefaultValue(false)]
        public virtual bool ItemDelete { get; set; }
    }
}
