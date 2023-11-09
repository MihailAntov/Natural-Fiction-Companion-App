using NFCombat2.Models.Player;


namespace NFCombat2.Contracts
{
    public interface IProfileService
    {
        public Task<bool> Save(string name);
        public IList<Player> GetAll();
        public Player CurrentPlayer();
        public Task SwitchActiveProfile(Player player); 
    }
}
