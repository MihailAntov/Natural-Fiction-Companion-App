

using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.Models.Items
{
    public class Item : IAddable, INotifyPropertyChanged
    {
        public int Id { get; set; }
        public ItemType Type { get; set; }
        public bool IsInvention { get; set; } = false;
        public string Name { get; set; }
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
