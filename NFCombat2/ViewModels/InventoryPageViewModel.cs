

using NFCombat2.Contracts;
using NFCombat2.Data.Entities.Items;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.Player;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class InventoryPageViewModel : INotifyPropertyChanged
    {
        private readonly IPlayerService _playerService;
        private readonly IItemService _itemService;
        private readonly IPopupService _popupService;

        public event PropertyChangedEventHandler PropertyChanged;
        public Command<string> AddToPlayerCommand;
        public InventoryPageViewModel(IPlayerService playerService, IItemService itemService, IPopupService popupService)
        {
            _playerService = playerService;
            _playerService.PropertyChanged += OnPlayerServicePropertyChanged;
            Player = _playerService.CurrentPlayer;
            Equipment = new ObservableCollection<Equipment>(Player.Equipment);
            _itemService = itemService;
            AddToPlayerCommand = new Command<string>(async (s)=> await AddToPlayer(s));
            _popupService = popupService;

        }
        public Player Player { get; set; }
        public ObservableCollection<Equipment> Equipment { get; set; }
        private List<Item> _allItems = new List<Item>();
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
        public async Task AddToPlayer(string type)
        {
            ICollection<IAddable> options = new List<IAddable>();
            switch (type)
            {
                case "item":
                    options = await LoadItemsAsync();
                    break;
                case "weapon":
                    options = await LoadItemsAsync();
                    break;
                case "equipment":
                    options = await LoadItemsAsync();
                    break;
            }

            var taskCompletion = await _popupService.ShowEntryWithSuggestionsPopup(_playerService, options);
            await taskCompletion.Task;
        }

        private async Task<ICollection<IAddable>> LoadItemsAsync()
        {
            return await _itemService.GetAllItems();
        }
        private async Task<ICollection<IAddable>> LoadWeaponsAsync()
        {
            return await _itemService.GetAllWeapons();
        }
        private async Task<ICollection<IAddable>> LoadEquipmentAsync()
        {
            return await _itemService.GetAllEquipment();
        }

        public int InventorySlots  => Player.InventorySlots;

       

        

        


        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void OnPlayerServicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_playerService.CurrentPlayer))
            {
                Player = _playerService.CurrentPlayer;
                Equipment.Clear();
                foreach(var item in Player.Equipment)
                {
                    Equipment.Add(item);
                }
            }
        }
    }
}
