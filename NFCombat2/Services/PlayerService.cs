

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
        public PlayerService(PlayerRepository repository, SettingsRepository settings, IMapper mapper)
        {
            _repository = repository;
            _settings = settings;
            _mapper = mapper;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        

        public Player CurrentPlayer
        {
            get
            {
                if(_player == null)
                {
                    _player = Task<Player>.Run(()=> _repository.GetAllProfiles()).Result.FirstOrDefault(); 
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

        public async Task<IList<Player>> GetAll()
        {
            return await _repository.GetAllProfiles();

            
        }

        public async Task<Player> GetById(int id)
        {
            var player = await _repository.GetById(id);
            return player;
        }

        public async Task<bool> Save(string name)
        {
            return await _repository.AddNewProfile(name);
        }

        public async Task SwitchActiveProfile(Player player)
        {
            CurrentPlayer = player;
            await Task.Run(async () =>
            {
               await _settings.UpdateCurrentPlayer(player.Id);

            });
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public void AddToPlayer(IAddable option)
        {
            if(option is Weapon weapon)
            {
                AddWeaponToPlayer(weapon, Hand.MainHand);
                return;
            }
            
            if(option is Equipment equipment)
            {
                CurrentPlayer.Equipment.Add(equipment);
                return;
            }

            if(option is Item item)
            {
                CurrentPlayer.Trinkets.Add(item);
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

            CurrentPlayer.Weapons[(int)hand] = weapon;
        }
    }
}
