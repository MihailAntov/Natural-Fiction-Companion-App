

using NFCombat2.Contracts;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Models.Items.Equipments;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class InventoryPageViewModel : INotifyPropertyChanged
    {
        private readonly IPlayerService _profileService;
        private readonly IOptionsService _optionsService;
        private readonly ItemRepository _itemRepository;

        public InventoryPageViewModel(IPlayerService profileService, IOptionsService optionsService, ItemRepository itemRepository)
        {
            _profileService = profileService;
            _optionsService = optionsService;
            _itemRepository = itemRepository;
            Equipment = new ObservableCollection<Equipment>(_profileService.CurrentPlayer().Equipment);
            
        }

        public ObservableCollection<Equipment> Equipment { get; set; }
        private double _hpValue;

        public event PropertyChangedEventHandler PropertyChanged;

        public double HpValue { get { return _hpValue; } set 
            {
                
              if (_hpValue != Math.Round(value, 0))
                {
                    _hpValue = Math.Round(value, 0);
                    OnPropertyChanged(nameof(HpValue));
                }
                
            }
        }

        public void TextChanged(string input)
        {
            var items = _profileService
                .CurrentPlayer()
                .Equipment
                .Where(e => e.Name.StartsWith(input))
                .ToList();

            
        }

       

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
