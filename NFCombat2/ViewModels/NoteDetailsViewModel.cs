using NFCombat2.Models.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.ViewModels
{
    public class NoteDetailsViewModel
    {
        private Note _note;
        public NoteDetailsViewModel(Note note)
        {
            _note = note;
        }


    }
}
