using DataTriggerCorruptedExample.Database.Helpers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace DataTriggerCorruptedExample.DatabaseModels
{
    public class StoreSelection : INotifyPropertyChanged
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
            set
            {
                if (_savedStore != value)
                {
                    _savedStore = value;
                    if (_savedStore != null)
                    {
                        SavedStoreId = _savedStore.Id;
                    }

                    NotifyPropertyChanged(nameof(SavedStoreItem));
                }
            }
        }

        #endregion

        #region StoreItem

        [Column(Order = 3)]
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public virtual Store StoreItem
        {
            get => _storeItem;
            set
            {
                if (_storeItem != value)
                {
                    _storeItem = value;
                    if (_storeItem != null)
                    {
                        StoreId = _storeItem.Id;
                    }

                    NotifyPropertyChanged(nameof(StoreItem));
                }
            }
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
            set 
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    NotifyPropertyChanged(nameof(IsSelected));
                }
            }
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
                _min = value;
                NotifyPropertyChanged(nameof(IsValid));
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
                _max = value;
                NotifyPropertyChanged(nameof(IsValid));
            }
        }

        #endregion

        #region Optimal Profit

        private int _optimalProfit = 0;

        [Column(Order = 8)]
        public int OptimalProfit
        {
            get => _optimalProfit;
            set
            {
                _optimalProfit = value;
                NotifyPropertyChanged(nameof(OptimalProfit));
            }
        }

        #endregion        

        #region IsValid

        [NotMapped]
        [Column(Order = 9)]
        public bool IsValid { get => Max >= Min; }

        #endregion



        #region Eventing

        private readonly WeakEvent<PropertyChangedEventHandler> _propertyChangedEvent = new WeakEvent<PropertyChangedEventHandler>();

        event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
        {
            add => _propertyChangedEvent.AddHandler(value);
            remove => _propertyChangedEvent.RemoveHandler(value);
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            _propertyChangedEvent.RaiseEvent(handler => handler.Invoke(this, new PropertyChangedEventArgs(propertyName)));
        }

        #endregion                
    }
}
