using NFCombat2.Models.Fights;
using NFCombat2.Models.Contracts;
using NFCombat2.Common.Enums;

namespace NFCombat2.Contracts
{
    public interface IFightService
    {
        
        Task<Fight> GetFightByEpisodeNumber(int episodeNumber);
        Fight GetFight();
        public void AcceptFightResults();
        public void RejectFightResults();

        public bool Accepted { get; set; }

        Task AddEffect(ICombatAction effect);
        Task ResolveEffects();

        Task<IOptionList> ProcessChoice(object option);

        ITarget CurrentTargetingEffect { get; set; }
        IOptionList PreviousOptions { get; set; }
    }
}
