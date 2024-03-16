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
    public class NoteDetailsViewModel
    {
        private readonly INoteService _noteService;
        private NotePageViewModel _parent;
        public NoteDetailsViewModel(INoteService noteService, NotePageViewModel parent)
        {
            _noteService = noteService;
            DeleteNoteCommand = new Command(DeleteNote);
            SaveNoteCommand = new Command(SaveNote);
            _parent = parent;
        }

        public Note Note {get; set;}
        public Command SaveNoteCommand { get; set; }
        public Command DeleteNoteCommand { get; set; }

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


    }
}

