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
        public string PlayerName { get; }

        public Uri? CurrentPage { get; set; }

        public string? CurrentSave { get; set; }
        public Visibility LoadedGameSavePanel { get; set; }
        public Visibility NewGameSavePanel { get; set; } = Visibility.Hidden;

        public ObservableCollection<UniExamQuest.Quest> AvailableQuests { get; set; }
        public UniExamQuest.Quest SelectedQuest { get; set; }

        public GamePage()
        {
            PlayerName = MODEL.GM.State.Player.Name;
            CurrentSave = MODEL.GM.LoadedGameName;
            var quests = MODEL.GM.State.Quests;
            AvailableQuests = new ObservableCollection<UniExamQuest.Quest>(quests);
            CurrentPage = new Uri($"../View/PlayerPage.xaml", UriKind.Relative);
            showSavePanel(CurrentSave);

            Mediator.RegisterPropertyChanged<string>(showSavePanel, "SavePanel");
            Mediator.RegisterPropertyChanged<string>(ShowPageByName, "CurrentGamePage");
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
        private void showSavePanel(string gameName)
        {
            if (gameName == null)
                NewGameSavePanel = Visibility.Visible;
            else
            {
                NewGameSavePanel = Visibility.Hidden;
                LoadedGameSavePanel = Visibility.Visible;
                CurrentSave = MODEL.GM.LoadedGameName;
            }

            NotifyPropertyChanged("NewGameSavePanel");
            NotifyPropertyChanged("LoadedGameSavePanel");
            NotifyPropertyChanged("CurrentSave");
        }

    }
}