

using NFCombat2.Contracts;
using NFCombat2.Models.Player;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class LogPageViewModel : INotifyPropertyChanged
    {
        private readonly IPlayerService _playerService;
        public Player Player { get; set; }  
        public LogPageViewModel(IPlayerService playerService)
        {
            _playerService = playerService;
            Player = _playerService.CurrentPlayer;
            Title = $"{Player.Name}'s log";
        }
        private string _title;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void OnPlayerServicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_playerService.CurrentPlayer))
            {
                Player = _playerService.CurrentPlayer;
                Title = $"{Player.Name}'s log";
                
            }
        }
    }
}
