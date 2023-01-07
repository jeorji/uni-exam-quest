using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UI.Model;

namespace UI.ViewModel
{
    internal class PlayerPage : DefaultViewModel
    {
        private UniExamQuest.IPlayer player;
        public UniExamQuest.IPlayer Player { get; set; }
        public int CurrentDay { get; set; }
        public int MindToUpLevel { get; set; }
        public int CurrentLevel
        {
            get => (int)(Player.Mind / MindToUpLevel);
        }
        public int CurrentMind
        {
            get => (int)(Player.Mind - CurrentLevel * MindToUpLevel);
        }
        public List<KeyValuePair<UniExamQuest.Item, int>> InventoryItems { get; set; }
        private KeyValuePair<UniExamQuest.Item, int>? selectedItem;
        public KeyValuePair<UniExamQuest.Item, int>? SelectedItem 
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                NotifyPropertyChanged();
            }
        }
        public PlayerPage()
        {
            Player = MODEL.GM.State.Player;
            MindToUpLevel = MODEL.GM.State.Settings.MindToUpLevel;
            CurrentDay = MODEL.GM.State.Day;
            InventoryItems = MODEL.GM.State.Player.Inventory.Content.ToList();
        }
        private Command? _useItem;
        public Command UseItem
        {
            get
            {
                _useItem ??= new Command(
                    p => SelectedItem is not null,
                    p =>
                    {
                        Player.InteractWith(SelectedItem?.Key);
                        Player.Inventory.Remove(SelectedItem?.Key);
                        InventoryItems = Player.Inventory.Content.ToList();

                        NotifyPropertyChanged("CurrentLevel");
                        NotifyPropertyChanged("CurrentMind");
                        NotifyPropertyChanged("InventoryItems");
                        NotifyPropertyChanged("SelectedItem");
                        NotifyPropertyChanged("Player");
                    });

                return _useItem;
            }
        }
    }
}
