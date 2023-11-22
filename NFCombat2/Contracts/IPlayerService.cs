using NFCombat2.Models.Player;
using NFCombat2.Models.Items;
using System.ComponentModel;
using NFCombat2.Models.Contracts;
using NFCombat2.Common.Enums;

namespace NFCombat2.Contracts
{
    public interface IPlayerService
    {
        public Task<Player> Save(Player player);
        public Task<IList<Player>> GetAll();
        public Player CurrentPlayer { get; set; }
        public Task SwitchActiveProfile(Player player);
        public event PropertyChangedEventHandler PropertyChanged;
        public void AddToPlayer(IAddable item);
        public List<PlayerClass> GetClassOptions();
    }
}
