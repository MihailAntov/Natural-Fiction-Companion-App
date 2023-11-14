

using NFCombat2.Contracts;
using NFCombat2.Data.Entities.Repositories;
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
        private readonly IOptionsService _optionsService;
        private readonly IItemService _itemService;

        public event PropertyChangedEventHandler PropertyChanged;

        public InventoryPageViewModel(IPlayerService playerService, IOptionsService optionsService, IItemService itemService)
        {
            _playerService = playerService;
            _playerService.PropertyChanged += OnPlayerServicePropertyChanged;
            Player = _playerService.CurrentPlayer;
            _optionsService = optionsService;
            Equipment = new ObservableCollection<Equipment>(Player.Equipment);
            _itemService = itemService;
            
        }
        public Player Player { get; set; }
        public ObservableCollection<Equipment> Equipment { get; set; }

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
