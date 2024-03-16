using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Models.Notes
{
    public class Note : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _title;
        public string Title { get { return _title; } set
            {
                if(value != _title)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }
        private string _text;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Text { get { return _text; } set 
            {
                if(_text != value)
                {
                    _text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
