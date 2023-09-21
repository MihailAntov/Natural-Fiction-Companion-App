using NFCombat2.Models.Fights;

namespace NFCombat2.Services.Contracts
{
    public interface IFightService
    {
        Fight GetFightByEpisodeNumber(int episodeNumber);
    }
}
