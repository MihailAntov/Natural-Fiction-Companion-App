using NFCombat2.Contracts;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Models.Notes;
using NFCombat2.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Services
{
    public class NoteService : INoteService
    {
        private PlayerRepository _repository;
        public NoteService(PlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteNote(Note note)
        {
            await _repository.DeleteNote(note);
        }

        public async Task UpdateNote(Note note)
        {
            await _repository.UpdateNote(note);
        }

        public async Task<List<Note>> GetAllNotes(int playerId)
        {
            return await _repository.GetAllNotes(playerId);
        }

        public async Task<Note> CreateNote(int playerId)
        {
            return await _repository.AddNewNote(playerId);
        }

        public async Task<Note> GetNote(int noteId)
        {
            return await _repository.GetNote(noteId);
        }
    }
}
