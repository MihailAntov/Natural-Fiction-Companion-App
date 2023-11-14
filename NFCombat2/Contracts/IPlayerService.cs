using NFCombat2.Models.Player;
using System.ComponentModel;

namespace NFCombat2.Contracts
{
    public interface IPlayerService
    {
        public Task<bool> Save(string name);
        public IList<Player> GetAll();
        public Player CurrentPlayer { get; set; }
        public Task SwitchActiveProfile(Player player);
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
