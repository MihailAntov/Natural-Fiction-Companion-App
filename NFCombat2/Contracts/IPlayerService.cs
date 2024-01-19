using NFCombat2.Models.Player;
using NFCombat2.Models.Items;
using System.ComponentModel;
using NFCombat2.Models.Contracts;
using NFCombat2.Common.Enums;
using NFCombat2.Models.Items.Weapons;

namespace NFCombat2.Contracts
{
    public interface IPlayerService
    {
        public Task<Player> RegisterPlayer(Player player);
        public Task<Player> GetPlayerById(int id);
        public Task<IList<Player>> GetAllPlayers();
        public Player CurrentPlayer { get; set; }
        public Task SwitchToPlayer(Player player);
        public event PropertyChangedEventHandler PropertyChanged;
        public Task AddItemToPlayer(IAddable item);
        public Task AttachModificationToWeapon(IAddable option, AttachedTo hand);
        public Task RemoveItemFromPlayer(IAddable item);
        public List<PlayerClass> GetClassOptions();

        public Task SavePlayer();

        Task<ICollection<IAddable>> GetAllItems();
        Task<ICollection<IAddable>> GetAllWeapons();
        Task<ICollection<IAddable>> GetAllEquipment();
        Task<ICollection<IAddable>> GetAllCraftables();
    }
}
