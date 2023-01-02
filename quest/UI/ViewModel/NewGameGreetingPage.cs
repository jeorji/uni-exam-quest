using System;
using System.Windows;
using UI.Model;

namespace UI.ViewModel
{
    internal class NewGameGreetingPage : DefaultViewModel
    {
        public string NewUserName { get; set; }

        private Command? startGame;
        public Command StartGame
        {
            get
            {
                startGame ??= new Command(
                    p => NewUserName is not null && NewUserName.Length > 0,
                    p => NewGameWithUserName(p));
                return startGame;
            }
        }
        private void NewGameWithUserName(object userName)
        {
            MainWindow mw = (MainWindow)Application.Current.FindResource("MainWindow");
            mw.ShowPageByName("GamePage");
            MODEL.GM.NewGame(NewUserName);
        }
    }
}