using NFCombat2.Models.Notes;
using NFCombat2.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Contracts
{
    public interface INoteService
    {
        Task UpdateNote(Note note);
        Task DeleteNote(Note note);
        Task CreateNote(string title, Player player);
        Task<List<Note>> GetAllNotes(int playerId);
    }
}
