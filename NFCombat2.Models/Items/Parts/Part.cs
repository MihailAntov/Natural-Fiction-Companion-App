using NFCombat2.Common.Enums;

namespace NFCombat2.Models.Items.Parts
{
    public class Part : Item
    {
        public PartType PartType { get; set; }
        public WorkCoefficient WorkCoefficient { get; set; }
        private int _currentlySelected = 0;
        public int CurrentlySelected { get { return _currentlySelected; } set 
            {
                if(_currentlySelected != value)
                {
                    _currentlySelected = value;
                    OnPropertyChanged(nameof(CurrentlySelected));
                }
            }
        }
    }
}
