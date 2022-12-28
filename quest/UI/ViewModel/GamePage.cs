using UI.Model;

namespace UI.ViewModel
{
    internal class GamePage : DefaultViewModel
    {
        public string PlayerName { get; set; } = MODEL.GM.State.Player.Name;
    }
}