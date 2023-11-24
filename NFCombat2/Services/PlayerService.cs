

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

namespace NFCombat2.Services
{
    public class PlayerService : IPlayerService, INotifyPropertyChanged
    {
        private PlayerRepository _repository;
        private SettingsRepository _settings;
        private IMapper _mapper;
        private Player _player;
        private ISeederService _seederService;
        public PlayerService(PlayerRepository repository,
            SettingsRepository settings,
            IMapper mapper,
            ISeederService seederService)
        {
            _repository = repository;
            _settings = settings;
            _mapper = mapper;
            GetDefaultPlayer();
            if (repository.ShouldSeed)
            {
            
                _seederService = seederService;
                _seederService.SeedItems();
            }

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

        public async Task<Player> UpdatePlayer(Player player)
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
                AddWeaponToPlayer(weapon, Hand.MainHand);
                await _repository.UpdatePlayer(_player);
                return;
            }
            
            if(option is Equipment equipment)
            {
                CurrentPlayer.Equipment.Add(equipment);
                await _repository.UpdatePlayer(_player);
                return;
            }

            if(option is Item item)
            {
                CurrentPlayer.Items.Add(item);
                await _repository.UpdatePlayer(_player);
                return;
            }

            
        }

        public void AddWeaponToPlayer(Weapon weapon, Hand hand)
        {
            if(weapon.Weight > CurrentPlayer.MaxWeaponWeight)
            {
                CurrentPlayer.Weapons.Clear();
                CurrentPlayer.Weapons.Add(weapon);
                return;
            }
            else if(CurrentPlayer.Weapons.Count < 2)
            {
                
            }
            


            CurrentPlayer.Weapons[(int)hand] = weapon;
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
