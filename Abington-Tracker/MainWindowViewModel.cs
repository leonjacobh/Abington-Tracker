using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Abington_Tracker
{
    public class MainWindowViewModel
    {
        public ObservableCollection<ItemViewModel> Items { get; } = new ObservableCollection<ItemViewModel>();

        public MainWindowViewModel()
        {
            
                Items.Add(new ItemViewModel($"CSA Community Award (50+ Hours)"));
                Items.Add(new ItemViewModel($"CSA Service Award (200+ Hours)"));
                Items.Add(new ItemViewModel($"CSA Achievements Award (500+ Hours)"));

        }
    }
}