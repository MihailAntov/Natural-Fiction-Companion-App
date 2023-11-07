using NFCombat2.Models.Player;


namespace NFCombat2.Contracts
{
    public interface IProfileService
    {
        public void Save(string name);
        public List<Player> GetAll();
        public Player CurrentPlayer();
    }
}
