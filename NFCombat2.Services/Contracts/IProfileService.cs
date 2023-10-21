using NFCombat2.Models.Player;


namespace NFCombat2.Services.Contracts
{
    public interface IProfileService
    {
        public void Save(string name);
        public List<Player> GetAll();
    }
}
