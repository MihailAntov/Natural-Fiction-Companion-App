

using NFCombat2.Contracts;
using NFCombat2.Models.Items.Parts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class PartsBagViewModel : INotifyPropertyChanged
    {
        private PartBag _partBag;

        public PartsBagViewModel(IPlayerService playerService)
        {
            PartsBag = playerService.CurrentPlayer.PartsBag;
            ExpandTabCommand = new Command<PartCategory>(ExpandTab);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command ExpandTabCommand { get; set; }
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
        public void ExpandTab(PartCategory partCategory)
        {
            partCategory.IsExpanded = !partCategory.IsExpanded;
        }


        

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
