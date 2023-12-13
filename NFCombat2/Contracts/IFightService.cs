using NFCombat2.Models.Fights;
using NFCombat2.Models.Contracts;
using NFCombat2.Common.Enums;
using System.ComponentModel;

namespace NFCombat2.Contracts
{
    public interface IFightService : INotifyPropertyChanged
    {
        
        Task<Fight> GetFightByEpisodeNumber(int episodeNumber);
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
