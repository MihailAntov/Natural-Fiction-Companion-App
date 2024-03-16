

using NFCombat2.Contracts;
using NFCombat2.Models.Notes;
using NFCombat2.Models.Player;
using NFCombat2.Pages;
using NFCombat2.Services;
using NFCombat2.Views;
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
            CreateNoteCommand = new Command(CreateNote);
            OpenNoteCommand = new Command<int>(async (id)=> await OpenNote(id));
            _playerService.PropertyChanged += OnPlayerServicePropertyChanged;
            Notes = new ObservableCollection<Note>();
            LoadNotes();
            
        }
        private string _title;

        private async void LoadNotes()
        {
            var notes = await _noteService.GetAllNotes(_playerService.CurrentPlayer.Id);

            Notes.Clear();

            foreach(var note in notes)
            {
                Notes.Add(note);
            }
        }

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

        private async Task OpenNote(int noteId)
        {

            var note = await _noteService.GetNote(noteId);
            var vm = new NoteDetailsViewModel(_noteService);
            vm.Note = note;
            
            // todo: add navigation
            await Shell.Current.Navigation.PushAsync(new NoteDetails(vm));
        }

        public async void CreateNote()
        {
            var newId = await _noteService.CreateNote(_playerService.CurrentPlayer.Id);
            await OpenNote(newId);
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private async void OnPlayerServicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_playerService.CurrentPlayer))
            {
                Player = _playerService.CurrentPlayer;
                Title = $"{Player.Name}'s log";
                LoadNotes();
                
            }
        }
    }
}
