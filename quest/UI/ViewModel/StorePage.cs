using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.Model;

namespace UI.ViewModel
{
    internal class StorePage : DefaultViewModel
    {
        public ObservableCollection<UniExamQuest.Item> AvailableItems { get; set; }
        private UniExamQuest.Item selectedItem { get; set; }
        public UniExamQuest.Item SelectedItem
        {
            get => selectedItem;
            set
            {
                ItemPreview = Visibility.Visible;
                selectedItem = value;
                NotifyPropertyChanged("ItemPreview");
                NotifyPropertyChanged();
            }
        }
        public Visibility ItemPreview { get; set; }
        public StorePage() 
        {
            var items = MODEL.GM.State.Store.Items;
            AvailableItems = new ObservableCollection<UniExamQuest.Item>(items);
            ItemPreview = Visibility.Hidden;
        }
        private Command? _buyItem;
        public Command BuyItem
        {
            get
            {
                _buyItem ??= new Command(
                    p => isMoneyEnought(),
                    p =>
                    {
                        MODEL.GM.State.Player.BuyItem(SelectedItem);
                        MessageBox.Show($"Куплено {SelectedItem.Name}!");
                    });
                return _buyItem;
            }
        }

        private bool isMoneyEnought()
        {
            if (SelectedItem is not null)
                return MODEL.GM.State.Player.Money >= SelectedItem.Price;
            return false;
        }
    }
}
