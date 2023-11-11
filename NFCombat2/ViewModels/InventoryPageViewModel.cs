

using NFCombat2.Contracts;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Models.Items;
using System.Collections.ObjectModel;

namespace NFCombat2.ViewModels
{
    public class InventoryPageViewModel
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

        public void TextChanged(string input)
        {
            var items = _profileService
                .CurrentPlayer()
                .Equipment
                .Where(e => e.Label.StartsWith(input))
                .ToList();

            
        }
    }
}
