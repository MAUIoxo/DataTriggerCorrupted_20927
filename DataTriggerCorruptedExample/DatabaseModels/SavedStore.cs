using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataTriggerCorruptedExample.DatabaseModels
{
    public class SavedStore
    {
        [Key]                                                               // Primary Key will already be indexed in a Table
        [Column(Order = 1)]
        public int Id { get; set; }



        [Required]
        [Column(Order = 2, TypeName = "TEXT COLLATE NOCASE")]               // Ignore case sensitivity for the Unique Constraint
        public string Name { get; set; }

        [Column(Order = 3)]
        public bool ModifiedSinceLastSave { get; set; }

        [Column(Order = 4)]
        public DateTime LastSavedDate { get; set; } = DateTime.Now;



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
