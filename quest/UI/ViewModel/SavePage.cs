using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.Model;

namespace UI.ViewModel
{
    class SavePage : DefaultViewModel
    {
        public string? SaveName { get; set; }
        //public string

        private Command? _saveGame;
        public Command SaveGame
        {
            get
            {
                _saveGame ??= new Command(
                    p => SaveName is not null,
                    p =>
                    {
                        MODEL.GM.SaveGame(SaveName);
                        Mediator.SendPropertyChanged<string>("SavePanel", SaveName);
                    });
                return _saveGame;
            }
        }
    }
}
