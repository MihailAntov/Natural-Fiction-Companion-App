

using NFCombat2.Contracts;
using NFCombat2.Data.Entities.Items;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Items;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.Items.Weapons;
using NFCombat2.Models.Player;
using NFCombat2.Common.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class InventoryPageViewModel : INotifyPropertyChanged
    {
        private readonly IPlayerService _playerService;
        private readonly IPopupService _popupService;
        private string _title;
        public string Title { get { return _title; } set 
            {
                if(_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            } 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public Command AddToPlayerCommand { get; set; }
        public Command AddWeaponToPlayerCommand { get; set; }
        public InventoryPageViewModel(IPlayerService playerService, IPopupService popupService)
        {
            _playerService = playerService;
            _playerService.PropertyChanged += OnPlayerServicePropertyChanged;
            Player = _playerService.CurrentPlayer;
            Items = new ObservableCollection<Item>(Player.Items);
            Equipment = new ObservableCollection<Equipment>(Player.Equipment);
            AddToPlayerCommand = new Command<string>(async (s)=> await AddToPlayer(s));
            AddWeaponToPlayerCommand = new Command<string>(async (s) => await AddWeaponToPlayer(s));
            _popupService = popupService;
            Title = $"{Player.Name}'s inventory";

        }
        public Player Player { get; set; }
        public Weapon MainHand { get; set; }
        public Weapon OffHand { get; set; }
        public ObservableCollection<Weapon> Weapons { get; set; } = new ObservableCollection<Weapon>();
        public ObservableCollection<Equipment> Equipment { get; set; }
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
                    options = await LoadWeaponsAsync();
                    break;
                case "equipment":
                    options = await LoadEquipmentAsync();
                    break;
            }

            var taskCompletion = await _popupService.ShowEntryWithSuggestionsPopup(_playerService, options);
            var added = await taskCompletion.Task;
            AddToObservalbeCollection(added);
        }

        public async Task AddWeaponToPlayer(string hand)
        {
            
            var options = await LoadWeaponsAsync();
            foreach(var option in options)
            {
                if(option is Weapon weapon)
                weapon.Hand = hand == "main" ? Hand.MainHand : Hand.OffHand;
            }

            var taskCompletion = await _popupService.ShowEntryWithSuggestionsPopup(_playerService, options);
            var added = await taskCompletion.Task;
            switch (hand)
            {
                case "main":
                    MainHand = (Weapon)added;
                    break;
                case "off":
                    OffHand = (Weapon)added;
                    break;
            }
            
        }

        private async Task<ICollection<IAddable>> LoadItemsAsync()
        {
            return await _playerService.GetAllItems();
        }
        private async Task<ICollection<IAddable>> LoadWeaponsAsync()
        {
            return await _playerService.GetAllWeapons();
        }
        private async Task<ICollection<IAddable>> LoadEquipmentAsync()
        {
            return await _playerService.GetAllEquipment();
        }

        public void AddToObservalbeCollection(IAddable added)
        {
            if(added is Weapon weapon)
            {
                Weapons.Add(weapon);
                return;
            }

            if(added is Equipment equipment)
            {
                Equipment.Add(equipment);
                return;
            }

            Items.Add((Item)added);
        }

        public int InventorySlots  => Player.InventorySlots;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void OnPlayerServicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_playerService.CurrentPlayer))
            {
                Player = _playerService.CurrentPlayer;
                Title = $"{Player.Name}'s inventory";
                Equipment.Clear();
                foreach(var item in Player.Equipment)
                {
                    Equipment.Add(item);
                }

                Items.Clear();
                foreach (var item in Player.Items)
                {
                    Items.Add(item);
                }
            }
        }
    }
}
