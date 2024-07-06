

using NFCombat2.Models.Player;
using NFCombat2.Contracts;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Models.Items.Equipments;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NFCombat2.Models.Items;
using NFCombat2.Models.Items.Weapons;
using NFCombat2.Common.Enums;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.SpecOps;
using NFCombat2.ViewModels;
using NFCombat2.Views;

namespace NFCombat2.Services
{
    public class PlayerService : IPlayerService, INotifyPropertyChanged
    {
        private PlayerRepository _repository;
        private readonly IMyPopupService _popupService;
        //private SettingsRepository _settings;
        private readonly ISettingsService _settingsService;
        private readonly IProgramService _programService;
        private readonly INameService _nameService;
        private Player _player = new Player();
        public PlayerService(PlayerRepository repository,
            //SettingsRepository settings,
            ISettingsService settingsService,
            IMyPopupService popupService,
            INameService nameService,
            IProgramService programService)
        {
            
            _repository = repository;
            //_settings = settings;
            _settingsService = settingsService;
            GetDefaultPlayer();
            _popupService = popupService;
            _nameService = nameService;
            _programService = programService;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        

        public Player CurrentPlayer
        {
            get
            {
                if(_player == null)
                {
                    GetDefaultPlayer();
                    
                }
                return _player;
                
            }
            set
            {
                if(_player != value)
                {
                    _player = value;
                    OnPropertyChanged(nameof(CurrentPlayer));
                }
            }
        }

        public async Task<IList<Player>> GetAllPlayers()
        {
            
            var players =  await _repository.GetAllProfiles();
            foreach(var  player in players)
            {
                _programService.GetKnownPrograms(player);
            }
            return players;
        }

        public async void GetDefaultPlayer()
        {
            int currentPlayerId = await _settingsService.GetCurrentPlayerId();
            
            Player player = await GetPlayerById(currentPlayerId);
            if(player == null)
            {
                return;
                //player = (await GetAllPlayers()).FirstOrDefault();
            }
            await UpdateNames(player);
            CurrentPlayer = player;
            
        }

        public async Task UpdateNames(Player player)
        {
            if(player == null)
            {
                return;
            }
            Task task = new Task(() =>
            {

                foreach (var item in player.Items)
                {
                    item.Name = _nameService.ItemName(item.ItemType);
                    item.Description = _nameService.ItemDescription(item.ItemType);
                }

                foreach (var item in player.ExtraItems)
                {
                    item.Name = _nameService.ItemName(item.ItemType);
                    item.Description = _nameService.ItemDescription(item.ItemType);
                }

                foreach (var item in player.Equipment)
                {
                    item.Name = _nameService.ItemName(item.ItemType);
                    item.Description = _nameService.ItemDescription(item.ItemType);
                }

                foreach(var weapon in player.Weapons)
                {
                    weapon.Name = _nameService.ItemName(weapon.ItemType);
                    weapon.Description = _nameService.ItemDescription(weapon.ItemType);
                }

                foreach (var category in player.PartsBag.Categories)
                {
                    category.Name = _nameService.PartCategoryName(category.PartCategoryType);
                    foreach(var part in category.Parts)
                    {
                        part.Name = _nameService.PartName(part.PartType);
                    }
                }

                
            });
            task.Start();
            await task;
            return;
        }

        public async Task<Player> GetPlayerById(int id)
        {
            var player = await _repository.GetPlayerById(id);
            _programService.GetKnownPrograms(player);
            return player;
        }

        public async Task<Player> RegisterPlayer(Player player)
        {
            player.Name = player.Name.Trim();
            var success = await _repository.AddNewProfile(player);
            if(success == null)
            {
                throw new InvalidDataException();
            }
            
            return success;
        }

        public async Task SwitchToPlayer(Player player)
        {
            //player = await _repository.GetPlayerById(player.Id);
            _programService.GetKnownPrograms(player);
            //?
            if (CurrentPlayer != null)
            {
                await _repository.UpdatePlayer(CurrentPlayer);
            }
            
            //var newPlayer = await GetPlayerById(player.Id);
            //if(newPlayer != null)
            //{
            //    player = newPlayer;
            //}
            await UpdateNames(player);
            CurrentPlayer = player;
            await _settingsService.SetCurrentPlayerId(player.Id);
        }



        public async Task AttachModificationToWeapon(IAddable option, AttachedTo hand)
        {
            if(option is WeaponModification modification)
            {
                modification.UnAttachFromWeapon();
                if(hand == AttachedTo.None)
                {
                    return;
                }

                Weapon weapon = hand == AttachedTo.MainHand ? CurrentPlayer.MainHand : CurrentPlayer.OffHand;
                modification.AttachToWeapon(weapon);
                await _repository.UpdatePlayer(CurrentPlayer);
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public async Task AddItemToPlayer(IAddable option)
        {
            if(option is Weapon weapon)
            {
                await AddWeaponToPlayer(weapon, weapon.Hand);
                if(weapon is IModifyPlayer modifier)
                {
                    modifier.OnAdded(CurrentPlayer);
                }
                await _repository.UpdatePlayer(CurrentPlayer);
                return;
            }
            
            if(option is Equipment equipment)
            {
                var existingEquipment = CurrentPlayer.Equipment.FirstOrDefault(e => e.Id == equipment.Id);
                if (existingEquipment != null && existingEquipment.IsConsumable)
                {
                    existingEquipment.Quantity++;
                    await _repository.UpdatePlayer(CurrentPlayer);
                    return;
                }
                CurrentPlayer.Equipment.Add(equipment);
                if(equipment is IModifyPlayer modifier)
                {
                    modifier.OnAdded(CurrentPlayer);
                }

                await _repository.UpdatePlayer(CurrentPlayer);
                OnPropertyChanged(nameof(CurrentPlayer));
                
                return;
            }

            if(option is Item item)
            {
                if(item.InExtraBag)
                {

                    var existingItem = CurrentPlayer.ExtraItems.FirstOrDefault(i=> i.Id == item.Id);
                    if(existingItem != null)
                    {
                        existingItem.Quantity++;
                        await _repository.UpdatePlayer(CurrentPlayer);
                        return;
                    }
                    CurrentPlayer.ExtraItems.Add(item);
                    await _repository.UpdatePlayer(CurrentPlayer);
                    OnPropertyChanged(nameof(CurrentPlayer));
                    return;
                }
                else
                {
                    var existingItem = CurrentPlayer.Items.FirstOrDefault(i => i.Id == item.Id);
                    if (existingItem != null && existingItem.IsConsumable)
                    {
                        existingItem.Quantity++;
                        await _repository.UpdatePlayer(CurrentPlayer);
                        return;
                    }
                    CurrentPlayer.Items.Add(item);
                    await _repository.UpdatePlayer(CurrentPlayer);
                    OnPropertyChanged(nameof(CurrentPlayer));
                    return;
                }
            }
        }

        public async Task RemoveItemFromPlayer(IAddable option)
        {
            if (option is Weapon weapon)
            {
                await RemoveWeaponFromPlayer(weapon);
                if(weapon is IModifyPlayer modifier)
                {
                    modifier.OnRemoved(CurrentPlayer);
                }
                await _repository.UpdatePlayer(CurrentPlayer);
                return;
            }

            if (option is Equipment equipment)
            {
                CurrentPlayer.Equipment.Remove(equipment);
                if(CurrentPlayer.Health > CurrentPlayer.MaxHealth)
                {
                    CurrentPlayer.Health = CurrentPlayer.MaxHealth;
                    OnPropertyChanged(nameof(CurrentPlayer.Health));
                }

                if (equipment is WeaponModification modification)
                {
                    modification.UnAttachFromWeapon();
                }

                if (equipment is IModifyPlayer modifier)
                {
                    modifier.OnRemoved(CurrentPlayer);
                }

                OnPropertyChanged(nameof(CurrentPlayer));
                await _repository.UpdatePlayer(CurrentPlayer);
                return;
            }

            if (option is Item item)
            {
                CurrentPlayer.Items.Remove(item);
                await _repository.UpdatePlayer(CurrentPlayer);
                return;
            }
        }

        

        private async Task AddWeaponToPlayer(Weapon weapon, Hand hand)
        {
            var otherWeapon = hand == Hand.MainHand ? CurrentPlayer.OffHand : CurrentPlayer.MainHand;
            if(otherWeapon != null)
            {
                if(weapon.Weight + otherWeapon.Weight > 2 * CurrentPlayer.MaxWeaponWeight)
                {
                    TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
                    //string confirmMessage = $"This will discard {otherWeapon.Name}. Are you sure?";
                    string confirmMessage = String.Format(_nameService.Label(LabelType.DiscardConfirm), otherWeapon.Name);
                    //todo !
                    var viewModel = new ConfirmationPopupViewModel(confirmMessage, taskCompletionSource, _nameService);
                    var popup = new ConfirmationPopupView(viewModel);
                    _popupService.ShowPopup(popup);
                    bool confirmed = await taskCompletionSource.Task;
                    await popup.CloseAsync();
                    if(!confirmed)
                    {
                        return;
                    }

                    if(hand == Hand.MainHand)
                    {
                        CurrentPlayer.OffHand = null;
                        CurrentPlayer.MainHand = weapon;
                        return;
                    }
                    else
                    {
                        CurrentPlayer.MainHand = null;
                        CurrentPlayer.OffHand = weapon;
                        return;
                    }

                }
            }

            Weapon oldWeapon = null;
            switch (hand)
            {
                case Hand.MainHand:
                    oldWeapon = CurrentPlayer.MainHand;
                    CurrentPlayer.MainHand = weapon;
                    break;
                case Hand.OffHand:
                    oldWeapon = CurrentPlayer.OffHand;
                    CurrentPlayer.OffHand = weapon;
                    break;
            }
            if(oldWeapon != null)
            {
                foreach(var modification in oldWeapon.Modifications)
                {
                    modification.UnAttachFromWeapon();
                }
            }
            
        }

        private async Task RemoveWeaponFromPlayer(Weapon weapon)
        {
            switch(weapon.Hand)
            {
                case Hand.MainHand:
                    CurrentPlayer.MainHand = null;
                    break;
                case Hand.OffHand:
                    CurrentPlayer.OffHand = null;
                    break;
            }
            await _repository.UpdatePlayer(CurrentPlayer);
        }

        public List<PlayerClassDisplay> GetClassOptions()
        {
            var list = new List<PlayerClassDisplay>();
            for(int i = 0; i < 5; i++)
            {
                PlayerClassDisplay next = new PlayerClassDisplay();
                next.Class = (PlayerClass)i;
                next.Name = _nameService.ClassName(next.Class);
                list.Add(next);
            }
            
            return list;
        }

        public async Task<ICollection<IAddable>> GetAllCraftables()
        {
            var craftables = await _repository.GetCraftableItems();
            foreach (var item in craftables)
            {
                item.Name = _nameService.ItemName(item.ItemType);
                item.Description = _nameService.ItemDescription(item.ItemType);
            }

            return craftables;
        }

        //public Task<ICollection<IAddable>> GetAllEquipment()
        //{
        //    return GetAllItemsByCategory(ItemCategory.Equipment);
        //}

        //public Task<ICollection<IAddable>> GetAllItems()
        //{
        //    return GetAllItemsByCategory(ItemCategory.Item);
        //}

        public Task<ICollection<IAddable>> GetAllAddableItems(ItemCategory category = ItemCategory.None)
        {
            if(category == ItemCategory.None)
            {
                return GetAllItemsByCategory(category);
            }
            return GetAllItemsByCategory();
        }

        public Task<ICollection<IAddable>> GetAllWeapons()
        {
            return GetAllItemsByCategory(ItemCategory.Weapon);
        }

        private async Task<ICollection<IAddable>> GetAllItemsByCategory(ItemCategory category = ItemCategory.None)
        {

            var entities = await _repository.GetItemsByCategory(category);
            foreach(var entity in entities)
            {
                if(entity is Item item)
                {
                    entity.Name = _nameService.ItemName(item.ItemType);
                    entity.Description = _nameService.ItemDescription(item.ItemType);
                }

                if (entity is Weapon weapon)
                {
                    entity.Name = _nameService.ItemName(weapon.ItemType);
                    entity.Description = _nameService.ItemDescription(weapon.ItemType);
                }

            }
            return entities;
        }

        public async Task SavePlayer()
        {
            if(CurrentPlayer != null)
            {
                await _repository.UpdatePlayer(CurrentPlayer);
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }

        public async Task DeletePlayer(Player player)
        {
            await _repository.DeletePlayer(player);
        }
    }
}
