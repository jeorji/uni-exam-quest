using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    internal class MainWindow : DefaultViewModel
    {
        public MainWindow()
        {
            //var tw = new UnicodeEncoding
            //var twix = new UniExamQuest.It("twxi", UniExamQuest.Quest.QuestType.UNIVERSIRTY);
            //var twix = new UniExamQuest.Item("twxi", 10);
            //var AL = new UniExamQuest.AssetsStorage(new UniExamQuest.XmlLoader());
            //AL.SaveToFile<List<UniExamQuest.Item>>(new List<UniExamQuest.Item>() { twix }, "./items.xml");

            ShowPageByName("StartPage");
        }

        public Uri? CurrentPage { get; set; }

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
