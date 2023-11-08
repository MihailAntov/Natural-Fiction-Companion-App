using NFCombat2.Models.Fights;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Contracts
{
    public interface IFightService
    {
        
        Task<Fight> GetFightByEpisodeNumber(int episodeNumber);
        Fight GetFight();

        Task AddEffect(ICombatAction effect);
        Task ResolveEffects();

        Task<IOptionList> ProcessChoice(object option);

        ITarget CurrentTargetingEffect { get; set; }
        IOptionList PreviousOptions { get; set; }
    }
}
