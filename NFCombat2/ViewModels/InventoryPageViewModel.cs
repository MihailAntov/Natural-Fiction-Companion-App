

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
using NFCombat2.Views;

namespace NFCombat2.ViewModels
{
    public class InventoryPageViewModel : INotifyPropertyChanged
    {
        private readonly IPlayerService _playerService;
        private readonly IOptionsService _optionsService;
        private readonly IPopupService _popupService;
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public Command AddToPlayerCommand { get; set; }
        public Command AddWeaponToPlayerCommand { get; set; }
        public InventoryPageViewModel(IPlayerService playerService, IPopupService popupService, IOptionsService optionsService)
        {
            _playerService = playerService;
            _optionsService = optionsService;
            _playerService.PropertyChanged += OnPlayerServicePropertyChanged;
            Player = _playerService.CurrentPlayer;
            Items = new ObservableCollection<Item>(Player.Items);
            Equipment = new ObservableCollection<Equipment>(Player.Equipment);
            SetInitialValues();
            AddToPlayerCommand = new Command<string>(async (s) => await AddToPlayer(s));
            AddWeaponToPlayerCommand = new Command<string>(async (s) => await AddWeaponToPlayer(s));
            _popupService = popupService;


        }
        public Player Player { get; set; }

        private void SetInitialValues()
        {
            UpdateWeaponDisplay();
            Title = $"{Player.Name}'s inventory";
        }

        private double _mainHandTransparency = 1;
        public double MainHandTransparency
        {
            get { return _mainHandTransparency; }
            set
            {
                if (_mainHandTransparency != value)
                {
                    _mainHandTransparency = value;
                    OnPropertyChanged(nameof(MainHandTransparency));
                }
            }
        }

        private double _offHandTransparency = 1;
        public double OffHandTransparency
        {
            get { return _offHandTransparency; }
            set
            {
                if (_offHandTransparency != value)
                {
                    _offHandTransparency = value;
                    OnPropertyChanged(nameof(OffHandTransparency));
                }
            }
        }

        private string _mainHandImage = "none";
        public string MainHandImage
        {
            get { return _mainHandImage; }
            set
            {
                if (_mainHandImage != value)
                {
                    _mainHandImage = value;
                    OnPropertyChanged(nameof(MainHandImage));
                }
            }
        }

        private string _offHandImage = "none";
        public string OffHandImage
        {
            get { return _offHandImage; }
            set
            {
                if (_offHandImage != value)
                {
                    _offHandImage = value;
                    OnPropertyChanged(nameof(OffHandImage));
                }
            }
        }

        private string _mainHandName;
        public string MainHandName
        {
            get { return _mainHandName; }
            set
            {
                if (_mainHandName != value)
                {
                    _mainHandName = value;
                    OnPropertyChanged(nameof(MainHandName));
                }
            }
        }
        private string _offHandName;
        public string OffHandName
        {
            get { return _offHandName; }
            set
            {
                if (_offHandName != value)
                {
                    _offHandName = value;
                    OnPropertyChanged(nameof(OffHandName));
                }
            }
        }

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
                //case "weapon":
                //    options = await LoadWeaponsAsync();
                //    break;
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
            foreach (var option in options)
            {
                if (option is Weapon weapon)
                    weapon.Hand = hand == "main" ? Hand.MainHand : Hand.OffHand;
            }

            var taskCompletion = await _popupService.ShowEntryWithSuggestionsPopup(_playerService, options);
            var added = await taskCompletion.Task;
            UpdateWeaponDisplay();


        }

        public async void UsedEquipment(object eventItem)
        {
            if (eventItem is WeaponModification modification)
            {
                TaskCompletionSource<bool> taskCompletionSource = new();
                var viewModel = new WeaponModificationViewModel(modification,_optionsService, _playerService, taskCompletionSource);
                var popup = new WeaponModificationView(viewModel);
                _popupService.ShowPopup(popup);
                var hand = await taskCompletionSource.Task;

            }
        }

        public void UsedItem(object eventItem)
        {
            if (eventItem is Item item)
            {
                item.Description = item.Description;
            }
        }

        private void UpdateWeaponDisplay()
        {
            if(_playerService.CurrentPlayer.MainHand == null && _playerService.CurrentPlayer.OffHand == null)
            {
                MainHandImage = "none";
                OffHandImage = "none";
                MainHandName = string.Empty;
                OffHandName = string.Empty;
            }


            if (_playerService.CurrentPlayer.MainHand != null)
            {
                MainHandImage = _playerService.CurrentPlayer.MainHand.Image;
                MainHandName = _playerService.CurrentPlayer.MainHand.Name;
                MainHandTransparency = 1;
                if (_playerService.CurrentPlayer.OffHand == null)
                {
                    OffHandName = string.Empty;
                    if (_playerService.CurrentPlayer.MainHand.Weight > _playerService.CurrentPlayer.MaxWeaponWeight)
                    {
                        OffHandImage = _playerService.CurrentPlayer.MainHand.Image;
                        OffHandTransparency = 0.5;
                    }
                    else
                    {
                        OffHandImage = "none";
                    }
                }
            }

            if (_playerService.CurrentPlayer.OffHand != null)
            {
                OffHandImage = _playerService.CurrentPlayer.OffHand.Image;
                OffHandName = _playerService.CurrentPlayer.OffHand.Name;
                OffHandTransparency = 1;
                if (_playerService.CurrentPlayer.MainHand == null)
                {
                    MainHandName = string.Empty;
                    if (_playerService.CurrentPlayer.OffHand.Weight > _playerService.CurrentPlayer.MaxWeaponWeight)
                    {
                        MainHandImage = _playerService.CurrentPlayer.OffHand.Image;
                        MainHandTransparency = 0.5;
                    }
                    else
                    {
                        MainHandImage = "none";
                    }
                }


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
            if (added is Weapon weapon)
            {
                Weapons.Add(weapon);
                return;
            }

            if (added is Equipment equipment)
            {
                Equipment.Add(equipment);
                return;
            }

            Items.Add((Item)added);
        }

        public int InventorySlots => Player.InventorySlots;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void OnPlayerServicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_playerService.CurrentPlayer))
            {
                Player = _playerService.CurrentPlayer;
                Title = $"{Player.Name}'s inventory";
                Equipment.Clear();
                foreach (var item in Player.Equipment)
                {
                    Equipment.Add(item);
                }

                Items.Clear();
                foreach (var item in Player.Items)
                {
                    Items.Add(item);
                }

                UpdateWeaponDisplay();
            }
        }
    }
}
