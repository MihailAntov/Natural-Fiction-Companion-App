using NFCombat2.Contracts;
using NFCombat2.Models.Notes;
using NFCombat2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.ViewModels
{
    public class NoteDetailsViewModel : BaseViewModel
    {
        private readonly INoteService _noteService;
        private NotePageViewModel _parent;
        public NoteDetailsViewModel(INoteService noteService, NotePageViewModel parent, INameService nameService) : base (nameService)
        {
            _noteService = noteService;
            DeleteNoteCommand = new Command(DeleteNote);
            SaveNoteCommand = new Command(SaveNote);
            UpdateLanguageSpecificProperties();
            _parent = parent;
        }

        public Note Note {get; set;}
        public Command SaveNoteCommand { get; set; }
        public Command DeleteNoteCommand { get; set; }

        private string _editorPlaceholder;
        public string EditorPlaceholder { get { return _editorPlaceholder; } set
            {
                if(_editorPlaceholder != value )
                {
                    _editorPlaceholder = value;
                    OnPropertyChanged(nameof(EditorPlaceholder));
                }
            } 
        }

        private string _titleEditorPlaceholder;
        public string TitleEditorPlaceholder
        {
            get { return _titleEditorPlaceholder; }
            set
            {
                if (_titleEditorPlaceholder != value)
                {
                    _titleEditorPlaceholder = value;
                    OnPropertyChanged(nameof(TitleEditorPlaceholder));
                }
            }
        }

        private string _saveButton;
        public string SaveButton { get { return _saveButton; } set
            {
                if(_saveButton != value)
                {
                    _saveButton = value;
                    OnPropertyChanged(nameof(SaveButton));
                }
            } 
        }

        public async void SaveNote()
        {
            
            await _noteService.UpdateNote(Note);
            await Shell.Current.Navigation.PopAsync();

        }
        public async void DeleteNote()
        {
            await _noteService.DeleteNote(Note);
            await Shell.Current.Navigation.PopAsync();
            _parent.Notes.Remove(Note);
        }

        public override void UpdateLanguageSpecificProperties()
        {
            EditorPlaceholder = _nameService.Label(Common.Enums.LabelType.EditorPlaceholder);
            TitleEditorPlaceholder = _nameService.Label(Common.Enums.LabelType.TitleEditorPlaceholder);
            SaveButton = _nameService.Label(Common.Enums.LabelType.SaveButton);
        }
    }
}

