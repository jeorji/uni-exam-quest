using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UI.ViewModel
{
    internal class MainWindow : DefaultViewModel
    {
        public MainWindow()
        {
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