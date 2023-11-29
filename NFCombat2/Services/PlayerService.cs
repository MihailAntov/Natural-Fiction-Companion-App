

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
using AutoMapper;
using NFCombat2.ViewModels;
using NFCombat2.Views;

namespace NFCombat2.Services
{
    public class PlayerService : IPlayerService, INotifyPropertyChanged
    {
        private PlayerRepository _repository;
        private IPopupService _popupService;
        private SettingsRepository _settings;
        private IMapper _mapper;
        private Player _player;
        //private ISeederService _seederService;
        public PlayerService(PlayerRepository repository,
            SettingsRepository settings,
            IMapper mapper,
            /*ISeederService seederService*/
            IPopupService popupService)
        {
            _repository = repository;
            _settings = settings;
            _mapper = mapper;
            _popupService = popupService;
            //GetDefaultPlayer();
            //if (repository.ShouldSeed)
            //{
            
            //    _seederService = seederService;
            //    _seederService.SeedItems();
            //}

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
            return players;
        }

        public async void GetDefaultPlayer()
        {
            int currentPlayerId = await _settings.CurrentPlayerId();
            
            Player player = await GetPlayerById(currentPlayerId);
            if(player == null)
            {
                player = (await GetAllPlayers()).FirstOrDefault();
            }
            CurrentPlayer = player;
            
        }

        public async Task<Player> GetPlayerById(int id)
        {
            var player = await _repository.GetPlayerById(id);
            return player;
        }

        public async Task<Player> RegisterPlayer(Player player)
        {
            var success = await _repository.AddNewProfile(player);
            if(success == null)
            {
                throw new InvalidDataException();
            }
            
            return success;
        }

        public async Task SwitchActivePlayer(Player player)
        {
            CurrentPlayer = await GetPlayerById(player.Id);
            await Task.Run(async () =>
            {
               await _settings.UpdateCurrentPlayer(player.Id);

            });
            
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public async Task AddItemToPlayer(IAddable option)
        {
            if(option is Weapon weapon)
            {
                await AddWeaponToPlayer(weapon, weapon.Hand);
                await _repository.UpdatePlayer(CurrentPlayer);
                return;
            }
            
            if(option is Equipment equipment)
            {
                CurrentPlayer.Equipment.Add(equipment);
                await _repository.UpdatePlayer(CurrentPlayer);
                return;
            }

            if(option is Item item)
            {
                CurrentPlayer.Items.Add(item);
                await _repository.UpdatePlayer(CurrentPlayer);
                return;
            }

            
        }

        public async Task RemoveItemFromPlayer(IAddable option)
        {
            if (option is Weapon weapon)
            {
                await RemoveWeaponFromPlayer(weapon);
                await _repository.UpdatePlayer(CurrentPlayer);
                return;
            }

            if (option is Equipment equipment)
            {
                CurrentPlayer.Equipment.Remove(equipment);
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
                    string confirmMessage = $"This will discard {otherWeapon.Name}. Are you sure?";
                    var viewModel = new ConfirmationPopupViewModel(confirmMessage, taskCompletionSource);
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


            switch (hand)
            {
                case Hand.MainHand:
                    CurrentPlayer.MainHand = weapon;
                    break;
                case Hand.OffHand:
                    CurrentPlayer.OffHand = weapon;
                    break;
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

        public List<PlayerClass> GetClassOptions()
        {
            var list = new List<PlayerClass>();
            list.Add(PlayerClass.None);
            list.Add(PlayerClass.Hacker);
            list.Add(PlayerClass.Engineer);
            list.Add(PlayerClass.Soldier);
            list.Add(PlayerClass.SpecOps);
            return list;
        }

        public Task<ICollection<IAddable>> GetAllEquipment()
        {
            return GetAllItemsByCategory(ItemCategory.Equipment);
        }

        public Task<ICollection<IAddable>> GetAllItems()
        {
            return GetAllItemsByCategory(ItemCategory.Item);
        }

        public Task<ICollection<IAddable>> GetAllWeapons()
        {
            return GetAllItemsByCategory(ItemCategory.Weapon);
        }

        private async Task<ICollection<IAddable>> GetAllItemsByCategory(ItemCategory category)
        {

            var entities = await _repository.GetItemsByCategory(category);

            return entities;
        }

        
    }
}
