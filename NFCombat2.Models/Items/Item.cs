

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.Models.Items
{
    public class Item : IAddable, INotifyPropertyChanged
    {
        public int Id { get; set; }
        public ItemType ItemType { get; set; }
        public bool IsInvention { get; set; } = false;
        private string _name;
        public string Name { get { return _name; } set 
            {
                if(_name != value )
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            } 
        }
        public string Description { get; set; }
        private int _quantity = 1;
        public int Quantity { get { return _quantity; }
            set
            {
                if(_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }
        public bool IsConsumable { get; set; } = false;
        public bool InExtraBag { get; set; }
        public string Formula { get; set; } = string.Empty;
        public int Episode { get; set; } = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
