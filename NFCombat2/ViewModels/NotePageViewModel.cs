

using NFCombat2.Common.Enums;
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
    public class NotePageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private readonly IPlayerService _playerService;
        private readonly INoteService _noteService;
        public Player Player { get; set; }  
        public NotePageViewModel(IPlayerService playerService, INoteService noteService, INameService nameService) : base(nameService)
        {
            _playerService = playerService;
            _noteService = noteService;
            Player = _playerService.CurrentPlayer;
            UpdateLanguageSpecificProperties();
            CreateNoteCommand = new Command(CreateNote);
            OpenNoteCommand = new Command<Note>(async (note)=> await OpenNote(note));
            _playerService.PropertyChanged += OnPlayerServicePropertyChanged;
            Notes = new ObservableCollection<Note>();
            LoadNotes();
            
        }
        private string _title;

        public async void LoadNotes()
        {
            var notes = await _noteService.GetAllNotes(_playerService.CurrentPlayer.Id);

            Notes.Clear();

            foreach(var note in notes)
            { 
                Notes.Add(note);
            }
        }


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

        private async Task OpenNote(Note note)
        {
            var vm = new NoteDetailsViewModel(_noteService, this, _nameService);
            vm.Note = note;
            
            // todo: add navigation
            await Shell.Current.Navigation.PushAsync(new NoteDetails(vm));
        }

        public async void CreateNote()
        {
            var newNote = await _noteService.CreateNote(_playerService.CurrentPlayer.Id);
            Notes.Add(newNote);
            await OpenNote(newNote);
        }


        private void OnPlayerServicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_playerService.CurrentPlayer))
            {
                Player = _playerService.CurrentPlayer;
                UpdateLanguageSpecificProperties();
                LoadNotes();
                
            }
        }

        public override void UpdateLanguageSpecificProperties()
        {
            Title = _nameService.Label(LabelType.NotePageTitle);
        }
    }
}
