using ControlsDemo.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlsDemo
{
    public class DummyData
    {
        public static async Task<IList<PickerModel>> GetItems()
        {
            return await Task<IList<PickerModel>>.Factory.StartNew(() =>
             {
                 return new List<PickerModel> {
                new PickerModel { ID = 1, Name = "Item 1", Abbr = "I 1" },
                new PickerModel { ID = 2, Name = "Item 2", Abbr = "I 2" },
                new PickerModel { ID = 3, Name = "Item 3", Abbr = "I 3" },
                new PickerModel { ID = 4, Name = "Item 4", Abbr = "I 4" },
                new PickerModel { ID = 5, Name = "Item 5", Abbr = "I 5" }};
             });
        }
    }
}
