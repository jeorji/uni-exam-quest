using System.Collections.ObjectModel;
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Media.Media3D;
using UI.Model;

namespace UI.ViewModel
{
    internal class GamePage : DefaultViewModel
    {
        public string PlayerName { get; } = MODEL.GM.State.Player.Name;

        public ObservableCollection<UniExamQuest.Quest> AvailableQuests { get; set; }
        public UniExamQuest.Quest SelectedQuest { get; set; }

        public ObservableCollection<UniExamQuest.Item> AvailableItems { get; set; }
        public UniExamQuest.Item SelectedItem { get; set; }

        public GamePage()
        {
            var quests = MODEL.GM.State.Quests;
            AvailableQuests = new ObservableCollection<UniExamQuest.Quest>(quests);

            var items = MODEL.GM.State.Store.Items;
            AvailableItems = new ObservableCollection<UniExamQuest.Item>(items);
        }
    }
}