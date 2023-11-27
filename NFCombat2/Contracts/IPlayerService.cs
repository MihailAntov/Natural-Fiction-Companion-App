using NFCombat2.Models.Player;
using NFCombat2.Models.Items;
using System.ComponentModel;
using NFCombat2.Models.Contracts;
using NFCombat2.Common.Enums;

namespace NFCombat2.Contracts
{
    public interface IPlayerService
    {
        public Task<Player> RegisterPlayer(Player player);
        public Task<IList<Player>> GetAllPlayers();
        public Player CurrentPlayer { get; set; }
        public Task SwitchActivePlayer(Player player);
        public event PropertyChangedEventHandler PropertyChanged;
        public Task AddItemToPlayer(IAddable item);
        public List<PlayerClass> GetClassOptions();

        Task<ICollection<IAddable>> GetAllItems();
        Task<ICollection<IAddable>> GetAllWeapons();
        Task<ICollection<IAddable>> GetAllEquipment();
    }
}
