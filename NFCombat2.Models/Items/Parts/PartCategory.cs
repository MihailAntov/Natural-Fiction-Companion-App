

using NFCombat2.Common.Enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.Models.Items.Parts
{
    public class PartCategory : INotifyPropertyChanged
    {
        private bool isExpanded = false;
        public string Name { get; set; }
        public PartCategoryType PartCategoryType { get; set; }
        public bool IsExpanded {  get { return isExpanded; }
            set
            {
                if(isExpanded != value)
                {
                    isExpanded = value;
                    OnPropertyChanged(nameof(IsExpanded));  
                }
            }
        }  
        public List<Part> Parts { get; set; } = new List<Part>();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
