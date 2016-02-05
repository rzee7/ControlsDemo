using ControlsDemo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlsDemo.ViewModel
{
    public class DemoPageViewModel : BaseViewModel
    {
        #region Constructor

        public DemoPageViewModel()
        {
            
        }

        #endregion

        #region Properties

        private IList<PickerModel> _pickerItems;
        public IList<PickerModel> PickerItems
        {
            get { return _pickerItems; }
            set { _pickerItems = value; OnPropertyChanged(); }
        }

        private PickerModel _selectedPickerItem;
        public PickerModel SelectedPickerItem
        {
            get { return _selectedPickerItem; }
            set { _selectedPickerItem = value; OnPropertyChanged(); }
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value; OnPropertyChanged();

                if (SelectedIndex > 0) // Using this condition we are making sure that we selecting valid Values!
                {
                    SelectedPickerItem = PickerItems[SelectedIndex];
                }
            }
        }
        #endregion

        #region Commands

        public ICommand LoadItemsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var items = await DummyData.GetItems();
                    PickerItems = items;
                });
            }
        }

        #endregion
    }
}
