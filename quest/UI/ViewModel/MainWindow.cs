using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UI.ViewModel
{
    internal class MainWindow : DefaultViewModel
    {
        public Uri? CurrentPage { get; set; }
        private Command _showPage;
        public Command ShowPage
        {
            get
            {
                if (_showPage == null)
                {
                    _showPage = new Command(
                        p => true,
                        p => showPageByName(p));
                }
                return _showPage;
            }
        }
        private void showPageByName(object name)
        {
            String viewFileName = name.ToString() switch
            {
                "StartPage" => "StartPage.xaml",
                _ => throw new Exception("Unimplemented view"),
            };
            CurrentPage = new Uri($"../View/{viewFileName}", UriKind.Relative);
            NotifyPropertyChanged("CurrentPage");
        }
    }
}