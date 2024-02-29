using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataTriggerCorruptedExampleDatabase
{
    public class SavedStore : ObservableObject
    {
        [Key]                                                               // Primary Key will already be indexed in a Table
        [Column(Order = 1)]
        public int Id { get; set; }


        #region Name

        private string _name;

        [Required]
        [Column(Order = 2, TypeName = "TEXT COLLATE NOCASE")]               // Ignore case sensitivity for the Unique Constraint
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        #endregion

        #region ModifiedSinceLastSave

        private bool _modifiedSinceLastSave;

        [Column(Order = 3)]
        public bool ModifiedSinceLastSave
        {
            get => _modifiedSinceLastSave;
            set => SetProperty(ref _modifiedSinceLastSave, value);
        }

        #endregion

        #region Name

        private DateTime _lastSavedDate = DateTime.Now;

        [Column(Order = 4)]
        public DateTime LastSavedDate
        {
            get => _lastSavedDate;
            set => SetProperty(ref _lastSavedDate, value);
        }


        #endregion



        private List<StoreSelection> _storeSelections;
        public virtual List<StoreSelection> StoreSelections
        {
            get
            {
                return _storeSelections ?? (_storeSelections = new List<StoreSelection>());

            }
        }
    }
}
