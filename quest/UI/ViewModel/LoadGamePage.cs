using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using UI.Model;

namespace UI.ViewModel
{
    class LoadGamePage : DefaultViewModel
    {
        public ObservableCollection<string> GameSaves { get; set; }
        public string? SelectedSave { get; set; }
        public LoadGamePage()
        {
            GameSaves = new ObservableCollection<string>(getFilesWithExtension("GameSaves/", ".bin"));
        }
        private Command? _loadSave;
        public Command LoadSave
        {
            get
            {
                _loadSave ??= new Command(
                    p => SelectedSave is not null,
                    p => startGameFromSave());
                return _loadSave;
            }
        }
        private Command? _backToMenu;
        public Command BackToMenu
        {
            get
            {
                _backToMenu ??= new Command(
                    p => true,
                    p =>
                    {
                        MainWindow mw = (MainWindow)Application.Current.FindResource("MainWindow");
                        mw.ShowPageByName("StartPage");
                    });
                return _backToMenu;
            }
        }
        private void startGameFromSave()
        {
            MainWindow mw = (MainWindow)Application.Current.FindResource("MainWindow");
            MODEL.GM.LoadGame(SelectedSave);
            mw.ShowPageByName("GamePage");
        }
        private List<string> getFilesWithExtension(string folderName, string extension)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(currentDirectory, folderName);
            List<string> files = new List<string>();
            foreach (string file in Directory.EnumerateFiles(folderPath))
            {
                if (Path.GetExtension(file) == extension)
                {
                    files.Add(Path.GetFileNameWithoutExtension(file));
                }
            }
            return files;
        }
    }
}
