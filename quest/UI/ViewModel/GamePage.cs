using System;
using System.Collections.ObjectModel;
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Xml.Linq;
using UI.Model;

namespace UI.ViewModel
{
    internal class GamePage : DefaultViewModel
    {
        public string PlayerName { get; } = MODEL.GM.State.Player.Name;
        public Uri? CurrentPage { get; set; }

        public ObservableCollection<UniExamQuest.Quest> AvailableQuests { get; set; }
        public UniExamQuest.Quest SelectedQuest { get; set; }

        public GamePage()
        {
            var quests = MODEL.GM.State.Quests;
            AvailableQuests = new ObservableCollection<UniExamQuest.Quest>(quests);
            CurrentPage = new Uri($"../View/PlayerPage.xaml", UriKind.Relative);
        }

        private Command? _showPage;
        public Command ShowPage
        {
            get
            {
                _showPage ??= new Command(
                    p => true,
                    p => ShowPageByName(p));
                return _showPage;
            }
        }
        public void ShowPageByName(object name)
        {
            CurrentPage = new Uri($"../View/{name.ToString()}.xaml", UriKind.Relative);
            NotifyPropertyChanged("CurrentPage");
        }
    }
}