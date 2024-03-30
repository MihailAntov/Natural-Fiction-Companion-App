

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
using Microsoft.Maui.Controls;
using NFCombat2.Models.Items.Parts;

namespace NFCombat2.ViewModels
{
    public class InventoryPageViewModel : INotifyPropertyChanged
    {
        private readonly IPlayerService _playerService;
        private readonly IOptionsService _optionsService;
        private readonly IPopupService _popupService;
        private readonly ILogService _logService;
        private readonly INameService _nameService;
        
        public InventoryPageViewModel(
            IPlayerService playerService,
            IPopupService popupService,
            IOptionsService optionsService,
            ILogService logService,
            INameService nameService)
        {
            _playerService = playerService;
            _optionsService = optionsService;
            _logService = logService;
            _nameService = nameService;
            _playerService.PropertyChanged += OnPlayerServicePropertyChanged;
            Player = _playerService.CurrentPlayer;
            Items = new ObservableCollection<Item>(Player.Items);
            Equipment = new ObservableCollection<Equipment>(Player.Equipment);
            ExtraItems = new ObservableCollection<Item>(Player.ExtraItems);
            SetInitialValues();
            AddToPlayerCommand = new Command<string>(async (s) => await AddToPlayer(s));
            DeleteCommand = new Command<IAddable>(async (a) => await RemoveFromPlayer(a));
            //AddWeaponToPlayerCommand = new Command<string>(async (s) => await AddWeaponToPlayer(s));
            GetWeaponDetailsCommand = new Command<string>(GetWeaponDetails);
            _popupService = popupService;
        }

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
        public Command GetWeaponDetailsCommand { get; set; }
        public Command DeleteCommand { get; set; }
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
        private bool _browsingEquipments = true;
        public bool BrowsingEquipments { get { return _browsingEquipments; }
            set
            {
                if(_browsingEquipments != value)
                {
                    _browsingEquipments = value;
                    OnPropertyChanged(nameof(BrowsingEquipments));
                }
            }
        }

        private bool _browsingItems = false;
        public bool BrowsingItems
        {
            get { return _browsingItems; }
            set
            {
                if (_browsingItems != value)
                {
                    _browsingItems = value;
                    OnPropertyChanged(nameof(BrowsingItems));
                }
            }
        }

        private bool _browsingParts = false;
        public bool BrowsingParts
        {
            get { return _browsingParts; }
            set
            {
                if (_browsingParts != value)
                {
                    _browsingParts = value;
                    OnPropertyChanged(nameof(BrowsingParts));
                }
            }
        }
        private bool _browsingExtraItems = false;
        public bool BrowsingExtraItems
        {
            get { return _browsingExtraItems; }
            set
            {
                if (_browsingExtraItems != value)
                {
                    _browsingExtraItems = value;
                    OnPropertyChanged(nameof(BrowsingExtraItems));
                }
            }
        }
        public ObservableCollection<Equipment> Equipment { get; set; } = new ObservableCollection<Equipment>();
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();
        public ObservableCollection<Part> Parts { get; set; } = new ObservableCollection<Part>();
        public ObservableCollection<Item> ExtraItems { get; set; } = new ObservableCollection<Item>();
        
        public async Task AddToPlayer(string type)
        {
            ICollection<IAddable> options = new List<IAddable>();
            switch (type)
            {
                case "item":
                    options = await LoadItemsAsync();
                    break;
                case "extraitem":
                    options = await LoadItemsAsync();
                    foreach(var option in options)
                    {
                        if(option is Item item)
                        {
                            item.InExtraBag = true;
                        }
                    }
                    break;
                case "equipment":
                    options = await LoadEquipmentAsync();
                    break;
            }

            var result = await _popupService.ShowEntryWithSuggestionsPopup(_playerService, options);
            if(result == null)
            {
                return;
            }

            AddToObservalbeCollection(result);
        }

        public async Task RemoveFromPlayer(IAddable addable)
        {
            if(addable is Equipment equipment)
            {
                await _playerService.RemoveItemFromPlayer(addable);
                

//                Player.Equipment.Remove(equipment);
                Equipment = new ObservableCollection<Equipment>(Player.Equipment);
                OnPropertyChanged(nameof(Player.Equipment));
                return;
            }

            if (addable is Weapon weapon)
            {
                //todo
                return;
            }



            if (addable is Item item)
            {
                if(item.InExtraBag)
                {
                    Player.ExtraItems.Remove(item);
                    ExtraItems.Remove(item);
                    return;
                }

                Player.Items.Remove(item);
                Items.Remove(item);
                return;

            }
        }

        public async Task AddWeaponToPlayer(Hand hand)
        {

            var options = await LoadWeaponsAsync();
            foreach (var option in options)
            {
                if (option is Weapon weapon)
                    weapon.Hand = hand;
            }

            await _popupService.ShowEntryWithSuggestionsPopup(_playerService, options);
            UpdateWeaponDisplay();


        }
        public async void GetWeaponDetails(string handAsString)
        {
            Weapon weapon = handAsString == "main" ? _playerService.CurrentPlayer.MainHand : _playerService.CurrentPlayer.OffHand;
            Hand hand = handAsString == "main" ? Hand.MainHand : Hand.OffHand;
            var viewModel = new WeaponDetailsPopupViewModel(weapon, this, _nameService, hand);
            var popup = new WeaponDetailsPopupView(viewModel);
            viewModel.Self = popup;
            _popupService.ShowPopup(popup);
        }

        public async void GetItemDetails(IAddable item)
        {
            var viewModel = new ItemDetailsPopupViewModel(item, this, _nameService);
            var popup = new ItemDetailsPopupView(viewModel);
            viewModel.Self = popup;
            _popupService.ShowPopup(popup);
        }

        public async void UsedItem(object eventItem)
        {
            if (eventItem is WeaponModification modification)
            {
                TaskCompletionSource<bool> taskCompletionSource = new();
                var viewModel = new WeaponModificationViewModel(modification,_optionsService, _playerService, taskCompletionSource);
                var popup = new WeaponModificationView(viewModel);
                viewModel.Popup = popup;
                _popupService.ShowPopup(popup);
                var completed = await taskCompletionSource.Task;
                if (completed)
                {
                    var resolution = modification.AffectPlayer(_playerService.CurrentPlayer);
                    string message = await _logService.GetResolutionMessage(resolution);
                    _popupService.ShowToast(message);
                    
                }
                return;
            }

            if(eventItem is IInventoryActiveItem item)
            {
                bool canReroll = Player.Class == PlayerClass.SpecOps;
                if(item is IHaveRolls rollsEffect)
                {
                    var taskCompletion = await _popupService.ShowDiceRollsPopup(rollsEffect, canReroll, 1);
                    await taskCompletion.Task;
                }

                var used = item.AffectPlayer(Player);
                if (item.IsConsumable)
                {
                    item.Quantity--;
                    if(item.Quantity == 0)
                    {
                        
                        Player.Items.Remove((Item)item);
                        Player.ExtraItems.Remove((Item)item);
                        if (item is Equipment)
                        {
                            Player.Equipment.Remove((Equipment)item);
                        }
                    }
                }

                await _playerService.SavePlayer();
                if(item.Quantity <= 0)
                {
                    Items.Remove((Item)eventItem);
                    ExtraItems.Remove((Item)eventItem);
                    if(item is Equipment)
                    {
                        Equipment.Remove((Equipment)eventItem);
                    }
                }

                string message = await _logService.GetResolutionMessage(used);
                _popupService.ShowToast(message);   
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

        public void ChangeTabState(string tab, bool isChecked)
        {
            switch (tab)
            {
                case "equipment":
                    BrowsingEquipments = isChecked;
                    break;
                case "items":
                    BrowsingItems = isChecked;
                    break;
                case "parts":
                    BrowsingParts = isChecked;
                    break;
                case "extraitems":
                    BrowsingExtraItems = isChecked;
                break;
            }
        }
        public void AddToObservalbeCollection(IAddable added)
        {

            //if (added is Equipment equipment)
            //{
            //    if(Equipment.Any(e=>e.Id == equipment.Id && e.IsConsumable))
            //    {
            //        return;
            //    }

            //    Equipment.Add(equipment);
            //    return;
            //}

            //if(Items.Any(i=> i.Id == added.Id))
            //{
            //    return;
            //}

            //Item item = (Item)added;
            //if(item.InExtraBag)
            //{
            //    ExtraItems.Add(item);
            //    return;
            //}
            
            //Items.Add(item);
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

                ExtraItems.Clear();
                foreach(var item in Player.ExtraItems)
                {
                    ExtraItems.Add(item);
                }

                

                OnPropertyChanged(nameof(Player));
                UpdateWeaponDisplay();
            }

            
        }
    }
}
