using ControlsDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ControlsDemo.Pages
{
    public partial class DemoPageFirst : ContentPage
    {
        public DemoPageViewModel ViewModel { get { return BindingContext as DemoPageViewModel; } }
        public DemoPageFirst()
        {
            BindingContext = new DemoPageViewModel();
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            ViewModel.LoadItemsCommand.Execute(null); //It should be below the above event
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PickerItems" && ViewModel.PickerItems != null && ViewModel.PickerItems.Count > 0)
            {
                for (int i = 0; i < ViewModel.PickerItems.Count + 1; i++)
                {
                    if (i == 0)
                        myPicker.Items.Add("Select Item"); //Adding Place Holder on 0 Index, It will be useless
                    else
                        myPicker.Items.Add(ViewModel.PickerItems[i - 1].Name); // You can show anything like I'm showing Name: ViewModel.PickerItems[i].ID | ViewModel.PickerItems[i].Abbr
                }
                ViewModel.SelectedIndex = 0; //We are telling user that It's a Picker "Select Item"
            }
        }
    }
}
