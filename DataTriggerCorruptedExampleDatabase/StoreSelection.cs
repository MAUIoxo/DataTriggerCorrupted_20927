using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataTriggerCorruptedExampleDatabase
{
    public class StoreSelection : ObservableObject
    {
        #region Private Variables

        private SavedStore _savedStore;
        private Store _storeItem;

        #endregion


        [Key]                                                   // Primary Key will already be indexed in a Table
        [Column(Order = 1)]
        public int Id { get; set; }


        #region SavedStoreItem

        [Column(Order = 2)]
        [ForeignKey("SavedStore")]
        public int SavedStoreId { get; set; }
        public virtual SavedStore SavedStoreItem
        {
            get => _savedStore;
            set => SetProperty(ref _savedStore, value);
        }

        #endregion

        #region StoreItem

        [Column(Order = 3)]
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store StoreItem
        {
            get => _storeItem;
            set => SetProperty(ref _storeItem, value);
        }

        #endregion

        #region SortOrderIndex

        [Column(Order = 4)]
        [Range(1, int.MaxValue)]
        public int SortOrderIndex { get; set; }

        #endregion

        #region IsSelected

        private bool _isSelected = false;

        [NotMapped]
        [Column(Order = 5)]
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        #endregion

        #region Min Profit

        private int _min = 0;

        [Column(Order = 6)]
        public int Min
        {
            get => _min;
            set
            {
                SetProperty(ref _min, value);
                OnPropertyChanged(nameof(IsValid));
            }
        }

        #endregion

        #region Max Profit

        private int _max = 0;

        [Column(Order = 7)]
        public int Max
        {
            get => _max;
            set
            {
                SetProperty(ref _max, value);
                OnPropertyChanged(nameof(IsValid));
            }
        }

        #endregion

        #region Optimal Profit

        private int _optimalProfit = 0;

        [Column(Order = 8)]
        public int OptimalProfit
        {
            get => _optimalProfit;
            set => SetProperty(ref _optimalProfit, value);
        }

        #endregion        

        #region IsValid

        [NotMapped]
        [Column(Order = 9)]
        public bool IsValid { get => Max >= Min; }

        #endregion
    }
}
