using NFCombat2.Models.Player;


namespace NFCombat2.Contracts
{
    public interface IProfileService
    {
        public Task Save(string name);
        public Task<List<Player>> GetAll();
        public Task<Player> CurrentPlayer();
    }
}
