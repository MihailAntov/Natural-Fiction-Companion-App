using NFCombat2.Models.Fights;

namespace NFCombat2.Services.Contracts
{
    public interface IFightService
    {
        
        Task<Fight> GetFightByEpisodeNumber(int episodeNumber);
        Fight GetFight();
    }
}
