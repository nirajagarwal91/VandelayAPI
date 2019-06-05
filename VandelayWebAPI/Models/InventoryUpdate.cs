using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VandelayWebAPI.Models
{
    public class InventoryUpdate : InventoryItemManipulation
    {
        [Required(ErrorMessage = "You should fill out Item SKU.")]
        public override int ItemSKU
        {
            get { return base.ItemSKU; }
            set { base.ItemSKU = value; }
        }
        [Required(ErrorMessage = "You should fill out the Quantity.")]
        public override string ItemQuantity
        {
            get { return base.ItemQuantity; }
            set { base.ItemQuantity = value; }
        }
        [Required(ErrorMessage = "You should fill out description for the title.")]
        public override string ItemDescription
        {
            get { return base.ItemDescription; }
            set { base.ItemDescription = value; }
        }

        [DefaultValue(false)]
        public override bool ItemDelete
        {
            get { return base.ItemDelete; }
            set { base.ItemDelete = value; }
        }
    }
}
