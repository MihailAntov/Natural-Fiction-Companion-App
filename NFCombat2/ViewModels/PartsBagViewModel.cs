

using NFCombat2.Contracts;
using NFCombat2.Models.Items.Parts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class PartsBagViewModel : INotifyPropertyChanged
    {
        private PartBag _partBag;

        public event PropertyChangedEventHandler PropertyChanged;

        public PartBag PartsBag { get { return _partBag; } 
            set 
            {
                if(_partBag != value)
                {
                    _partBag = value;
                    OnPropertyChanged(nameof(PartsBag));
                }
            } 
        }
        public PartsBagViewModel(IPlayerService playerService)
        {
            PartsBag = playerService.CurrentPlayer.PartsBag;
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
