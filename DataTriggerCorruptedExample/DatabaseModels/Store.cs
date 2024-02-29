using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataTriggerCorruptedExample.DatabaseModels
{
    public class Store
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }


        [Required]
        [Column(Order = 2, TypeName = "TEXT COLLATE NOCASE")]              // Ignore case sensitivity for the Unique Constraint
        public string Name { get; set; }

        [Column(Order = 3)]
        public string Street { get; set; }

        [Column(Order = 4)]
        public double Manager { get; set; }

        [Column(Order = 5)]
        public double SalesPerson { get; set; }

        [Column(Order = 6)]
        public double Clerk { get; set; }


        private List<StoreSelection> _storeSelections;
        public virtual List<StoreSelection> StoreSelections
        {
            get
            {
                return this._storeSelections ?? (this._storeSelections = new List<StoreSelection>());
            }
        }
    }
}
