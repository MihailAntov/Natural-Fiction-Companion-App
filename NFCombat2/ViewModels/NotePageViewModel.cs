

using NFCombat2.Contracts;
using NFCombat2.Models.Notes;
using NFCombat2.Models.Player;
using NFCombat2.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class NotePageViewModel : INotifyPropertyChanged
    {
        private readonly IPlayerService _playerService;
        private readonly INoteService _noteService;
        public Player Player { get; set; }  
        public NotePageViewModel(IPlayerService playerService, INoteService noteService)
        {
            _playerService = playerService;
            _noteService = noteService;
            Player = _playerService.CurrentPlayer;
            Title = $"{Player.Name}'s log";
            CreateNoteCommand = new Command<string>(CreateNote);
            OpenNoteCommand = new Command<int>(OpenNote);
            _playerService.PropertyChanged += OnPlayerServicePropertyChanged;

        }
        private string _title;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Note> Notes { get; set; }
        public Command OpenNoteCommand { get; set; }
        public Command CreateNoteCommand { get; set; }
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

        private void OpenNote(int noteId)
        {

        }

        public void CreateNote(string noteTitle)
        {

        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private async void OnPlayerServicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_playerService.CurrentPlayer))
            {
                Player = _playerService.CurrentPlayer;
                Title = $"{Player.Name}'s log";

                Notes = new ObservableCollection<Note>(await _noteService.GetAllNotes(Player.Id));
                
            }
        }
    }
}
