

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

namespace NFCombat2.Services
{
    public class PlayerService : IPlayerService, INotifyPropertyChanged
    {
        private PlayerRepository repo;
        private Player _player;
        public PlayerService(PlayerRepository repository)
        {
            repo = repository;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Player CurrentPlayer
        {
            get
            {

                if(_player == null)
                {
                    _player =  GetAll().FirstOrDefault();
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

        public IList<Player> GetAll()
        {
            return repo.GetAllProfiles()
                .Select(p => new Player()
                {
                    Name = p.Name,
                    BaseMaxHealth = p.MaxHealth,
                    Health = p.Health
                }).ToList();

            
        }

        public async Task<bool> Save(string name)
        {
            return await repo.AddNewProfile(name);
        }

        public async Task SwitchActiveProfile(Player player)
        {
            await Task.Run(() =>
            {
                CurrentPlayer = player;
            });
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public void AddToPlayer(IAddable option)
        {
            if(option is Equipment equipment)
            {
                CurrentPlayer.Equipment.Add(equipment);
                return;
            }

            if(option is IConsumable consumable)
            {
                CurrentPlayer.Consumables.Add(consumable);
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
